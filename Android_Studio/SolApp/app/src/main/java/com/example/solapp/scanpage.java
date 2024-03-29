package com.example.solapp;

import android.animation.ArgbEvaluator;
import android.animation.ObjectAnimator;
import android.content.Context;
import android.content.res.AssetManager;
import android.graphics.Color;
import android.graphics.Typeface;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.Handler;
import android.text.InputType;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewParent;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.example.solapp.ChecklistJsonClass.Campi;
import com.example.solapp.ChecklistJsonClass.Checklist;
import com.example.solapp.ChecklistJsonClass.Chiavi_valori;
import com.example.solapp.ChecklistJsonClass.Transizioni;
import com.example.solapp.Singleton.GsonSingleton;
import com.example.solapp.Singleton.VolleySingleton;
import com.honeywell.aidc.BarcodeFailureEvent;
import com.honeywell.aidc.BarcodeReadEvent;
import com.honeywell.aidc.BarcodeReader;
import com.honeywell.aidc.ScannerNotClaimedException;
import com.honeywell.aidc.ScannerUnavailableException;
import com.honeywell.aidc.TriggerStateChangeEvent;
import com.honeywell.aidc.UnsupportedPropertyException;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.Scanner;

public class scanpage extends AppCompatActivity implements BarcodeReader.BarcodeListener, BarcodeReader.TriggerListener {

    public static Checklist jsonBase;
    private Checklist jsonfail;
    private String[] URL;
    private int esito;
    private LinearLayout linearLayout;
    private BarcodeReader barcodeReader;
    private List<View> listaElementi = new ArrayList<>();
    private List<View> listaTransizioni = new ArrayList<>();
    private LinearLayout elementiLinearLayout;
    public EditText activeEditText;
    private LinearLayout transizioniLinearLayout;
    private TableLayout LabelTabellare;

    private TableLayout boxDati;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setBarcodeReader();
        generateLinearLayout();
        initLogin();
        generadorBase();


    }

    private void setBarcodeReader() {
        barcodeReader = MainActivity.getBarcodeReader();

        ///////////////////////////////////////////////////////////
        //qui creo listanza del singleton del AidcMAnager
        //////////////////////////////////////////////////////////

//        Barcode
        if (barcodeReader != null) {
            //            qui gli asegno un listener
            barcodeReader.addBarcodeListener(this);
            try {
                barcodeReader.setProperty(BarcodeReader.PROPERTY_TRIGGER_CONTROL_MODE, BarcodeReader.TRIGGER_CONTROL_MODE_CLIENT_CONTROL);
            } catch (UnsupportedPropertyException e) {
                Toast.makeText(this, "Abbiamo Fallito a configurare le proprietà", Toast.LENGTH_LONG).show();
            }
            barcodeReader.addTriggerListener(this);

            Map<String, Object> properties = new HashMap<String, Object>();
            // Set Symbologies On/Off
            properties.put(BarcodeReader.PROPERTY_CODE_128_ENABLED, true);
            properties.put(BarcodeReader.PROPERTY_GS1_128_ENABLED, true);
            properties.put(BarcodeReader.PROPERTY_QR_CODE_ENABLED, true);
            properties.put(BarcodeReader.PROPERTY_CODE_39_ENABLED, true);
            properties.put(BarcodeReader.PROPERTY_DATAMATRIX_ENABLED, true);
            properties.put(BarcodeReader.PROPERTY_UPC_A_ENABLE, true);
            properties.put(BarcodeReader.PROPERTY_EAN_13_ENABLED, false);
            properties.put(BarcodeReader.PROPERTY_AZTEC_ENABLED, false);
            properties.put(BarcodeReader.PROPERTY_CODABAR_ENABLED, false);
            properties.put(BarcodeReader.PROPERTY_INTERLEAVED_25_ENABLED, false);
            properties.put(BarcodeReader.PROPERTY_PDF_417_ENABLED, false);
            // Set Max Code 39 barcode length
            properties.put(BarcodeReader.PROPERTY_CODE_39_MAXIMUM_LENGTH, 10);
            // Turn on center decoding
            properties.put(BarcodeReader.PROPERTY_CENTER_DECODE, true);
            // Enable bad read response
            properties.put(BarcodeReader.PROPERTY_NOTIFICATION_BAD_READ_ENABLED, true);
            // Sets time period for decoder timeout in any mode
            properties.put(BarcodeReader.PROPERTY_DECODER_TIMEOUT, 400);
            // Apply the settings
            barcodeReader.setProperties(properties);

        }
    }

    private void generateLinearLayout() {
        linearLayout = new LinearLayout(this);
        linearLayout.setOrientation(linearLayout.VERTICAL);
        ScrollView vistaPrincipale = new ScrollView(scanpage.this);
        vistaPrincipale.addView(linearLayout);
        setContentView(vistaPrincipale);
    }

    public void initLogin() {
//        Leggo il json in assets
        AssetManager assetManager = getAssets();
        try (InputStream inputStream = assetManager.open("Checklist.json")) {

            String string_json_Base = new Scanner(inputStream).useDelimiter("\\A").next();
            jsonBase = GsonSingleton.getGsonInstance().fromJson(string_json_Base, Checklist.class);
        } catch (IOException e) {
            Toast.makeText(this, "C'è un problemmino con il json BASE, o non sono riuscito a leggerlo", Toast.LENGTH_LONG).show();
        }

//        Lo inserisco in un array per fare in modo che al chiamarlo dopo dentro qualche metodo, non mi crei una copia, ma mi passi diretamente il riferimento al array
        URL = new String[1];
        URL[0] = "https://connettorepda.syncpointweb.it/ConnettorePDA/IdentificaPDA";
        jsonBase.getPda().setSerial_number("12345678");
    }

    public void generadorBase() {
        esito = jsonBase.getEsito().getErrore();
        if (esito == 0) {
            invioRicezioneJson(URL[0], toJsonObject(jsonBase), new JsonResponseListener() {
                @Override
                public void onResponse(JSONObject response) {

                    jsonfail = null;
                    jsonfail = GsonSingleton.getGsonInstance().fromJson(response.toString(), Checklist.class);

                    if (jsonfail.getEsito().getErrore() == 0) {
                        //jsonBase diventa il nuovo json risposta
                        jsonBase = jsonfail;
                        // Pulire le liste
                        listaElementi.clear();
                        listaTransizioni.clear();

                        linearLayout.removeAllViews();


                        List<Campi> campi = jsonBase.getPasso().getCampi();
                        List<Transizioni> transizioni = jsonBase.getPasso().getTransizioni();

                        elementiLinearLayout = new LinearLayout(scanpage.this);
                        elementiLinearLayout.setOrientation(linearLayout.VERTICAL);

//                        Tabella info del utente
                        LabelTabellare = new TableLayout(scanpage.this);
                        elementiLinearLayout.addView(LabelTabellare);
                        linearLayout.addView(elementiLinearLayout);


                        esito = jsonBase.getEsito().getErrore();

                        for (Campi campo :
                                campi) {
                            if (esito == 0) {
                                generateElemento(scanpage.this, listaElementi, campo, elementiLinearLayout);
                            } else {
                                Toast.makeText(scanpage.this, "errore: " + jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
                            }
                        }



                        transizioniLinearLayout = new LinearLayout(scanpage.this);
                        transizioniLinearLayout.setOrientation(linearLayout.VERTICAL);
                        linearLayout.addView(transizioniLinearLayout);
                        for (Transizioni transizione :
                                transizioni) {
                            if (esito == 0){
                                generateTransizione(listaTransizioni, transizione, transizioniLinearLayout);
                            }
                        }



                        ////////////////////////////
                        //                Bisogna fare attenzione, questo metodo avviene una volta creati tutti i rispettivi elementi o transizioni
                        initMenu();
                        ////////////////////////////
                    } else {
                        Toast.makeText(scanpage.this, "ErroreJson: " + jsonfail.getEsito().getDescrizione(), Toast.LENGTH_SHORT).show();
                    }

                }

                @Override
                public void onError(VolleyError e) {
                    e.printStackTrace();
                    Toast.makeText(scanpage.this, "volley error, perche ESITO : " + jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
                }
            });
        } else {
            Toast.makeText(this, "error da json: " + jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
        }

    }


    private void generateElemento(Context context, List<View> listaElementi, Campi elemento, ViewGroup contenitore) {

        /*
         * I listener permettono di farli modificabili tramite scanner
         * Ogni elemento(se neccesario) ha settato come tag il idCampo, il quale facilita la modifica nella logica
         * Per facilitare il cambiamento dei nomi degli elementi i nomi si trovano in values/strings.xml, in quel modo bisognera solo cambiare i nomi in quel file
         */
        if (elemento.getTipo().equals(getResources().getString(R.string.elemento_labeltabellare))) {

            TableRow row = new TableRow(context);
            row.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT,1));

            TextView Key = new TextView(context);
            Key.setText(elemento.getMsg());
            Key.setTypeface(null, Typeface.BOLD);
            Key.setBackgroundColor(getColor(R.color.label_tabellare_key));
            Key.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT,1));
            row.addView(Key);

            TextView Valore = new TextView(context);
            Valore.setText(elemento.getValore());
            Valore.setBackgroundColor(getColor(R.color.label_tabellare_valore));
            Valore.setTag(elemento.getId() + getResources().getString(R.string.elemento_labeltabellare));
            Valore.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT,3));
            row.addView(Valore);

            LabelTabellare.addView(row);
        } else if (elemento.getTipo().equals(getResources().getString(R.string.elemento_label))) {

            TextView Key = new TextView(context);
            Key.setText(elemento.getValore());
            Key.setTypeface(null, Typeface.BOLD);
            Key.setTag(elemento.getId() + getResources().getString(R.string.elemento_label));


            contenitore.addView(Key);

        } else if (elemento.getTipo().equals(getResources().getString(R.string.elemento_input))) {
            LinearLayout Input = new LinearLayout(context);
            Input.setOrientation(LinearLayout.VERTICAL);

            TextView tvInput = new TextView(context);
            tvInput.setText(elemento.getMsg());
            Input.addView(tvInput);

            EditText etElemento = new EditText(context);
            etElemento.setHint(elemento.getMsg());
            etElemento.setTag(elemento.getId() + getResources().getString(R.string.elemento_input));

//            Gli aggiungo un listener in modo che appena viene selezionato viene tracciato per il BarcodeReader
            etElemento.setOnFocusChangeListener(new View.OnFocusChangeListener() {
                @Override
                public void onFocusChange(View v, boolean hasFocus) {
                    if (hasFocus && v instanceof EditText) {
                        activeEditText = (EditText) v; // Guardar el EditText activo
                    }
                }
            });
//            Qua aggiungo a la lista il elemento
            listaElementi.add(etElemento);
            Input.addView(etElemento);

            contenitore.addView(Input);

        } else if (elemento.getTipo().equals(getResources().getString(R.string.elemento_password))) {
            LinearLayout Password = new LinearLayout(context);
            Password.setOrientation(LinearLayout.VERTICAL);

            TextView tvPassword = new TextView(context);
            tvPassword.setText(elemento.getMsg());
            Password.addView(tvPassword);

            EditText etPassword = new EditText(context);
            etPassword.setInputType(InputType.TYPE_CLASS_TEXT | InputType.TYPE_TEXT_VARIATION_PASSWORD);
            etPassword.setHint(elemento.getMsg());
            etPassword.setTag(elemento.getId() + getResources().getString(R.string.elemento_password));
//            Qua aggiungo a la lista il elemento
            listaElementi.add(etPassword);
            Password.addView(etPassword);

            contenitore.addView(Password);
        } else if (elemento.getTipo().equals(getResources().getString(R.string.elemento_textarea))) {
            LinearLayout TextArea = new LinearLayout(context);
            TextArea.setOrientation(LinearLayout.VERTICAL);

            TextView tvTextArea = new TextView(context);
            tvTextArea.setText(elemento.getMsg());
            TextArea.addView(tvTextArea);

            EditText etTextArea = new EditText(context);
            etTextArea.setHint(elemento.getMsg());
            etTextArea.setTag(elemento.getId() + getResources().getString(R.string.elemento_textarea));
            etTextArea.setGravity(Gravity.START | Gravity.TOP);
            etTextArea.setInputType(InputType.TYPE_TEXT_FLAG_MULTI_LINE);
            etTextArea.setLines(2);
            etTextArea.setMaxLines(5); // Esto permite un máximo de 10 líneas visibles
            etTextArea.setVerticalScrollBarEnabled(true);
            etTextArea.setHorizontallyScrolling(false);
//            Anche qui gli aggiungo il scanner nel caso voglia aggiungere il codice come texto
            etTextArea.setOnFocusChangeListener(new View.OnFocusChangeListener() {
                @Override
                public void onFocusChange(View v, boolean hasFocus) {
                    if (hasFocus && v instanceof EditText) {
                        activeEditText = (EditText) v; // Guardar el EditText activo
                    }
                }
            });

//            Qua aggiungo a la lista il elemento
            listaElementi.add(etTextArea);
            TextArea.addView(etTextArea);

            contenitore.addView(TextArea);

        } else if (elemento.getTipo().equals(getResources().getString(R.string.elemento_check))) {

            CheckBox checkBox = new CheckBox(context);
            checkBox.setText(elemento.getMsg());
            checkBox.setTag(elemento.getId() + getResources().getString(R.string.elemento_check));
            checkBox.setChecked(Boolean.parseBoolean(elemento.getValore()));


//            Qua aggiungo a la lista il elemento
            listaElementi.add(checkBox);

            contenitore.addView(checkBox);

        } else if (elemento.getTipo().equals(getResources().getString(R.string.elemento_listacontenitori))) {

            LinearLayout ListaContenitori = new LinearLayout(context);
            ListaContenitori.setOrientation(LinearLayout.VERTICAL);


            TextView tvListaContenitori = new TextView(context);
            tvListaContenitori.setText(elemento.getMsg());
            ListaContenitori.addView(tvListaContenitori);


            EditText etListaContenitori = new EditText(context);
            etListaContenitori.setTag(elemento.getId() + getResources().getString(R.string.elemento_listacontenitori));
            etListaContenitori.setOnFocusChangeListener(new View.OnFocusChangeListener() {
                @Override
                public void onFocusChange(View v, boolean hasFocus) {
                    if (hasFocus && v instanceof EditText) {
                        activeEditText = (EditText) v; // Guardar el EditText activo
                    }
                }
            });
            listaElementi.add(etListaContenitori);
            ListaContenitori.addView(etListaContenitori);


            TableLayout boxDati = new TableLayout(context);
            ListaContenitori.addView(boxDati);

            contenitore.addView(ListaContenitori);

        }

    }

    public void generateTransizione(List<View> listaTransizioni, Transizioni transizioni, ViewGroup contenitore) {

        Button btntransizione = new Button(this);
        btntransizione.setText(transizioni.getMsg());
        btntransizione.setLayoutParams(new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT, 1));
        btntransizione.setTag(transizioni.getId());
        listaTransizioni.add(btntransizione);

        contenitore.addView(btntransizione);
    }

    private void initMenu() {

        esito = jsonBase.getEsito().getErrore();
        if (esito == 0) {

            ///////////////////////////
            //      Dentro di raccoglitoreTransizioni avviene il racoglitore di elementi

            for (View transizione :
                    listaTransizioni) {
                raccoglitoreTransizioni(URL, jsonBase, transizione, listaElementi, new JsonResponseListener() {
                    @Override
                    public void onResponse(JSONObject response) {
                        if (esito == 0) {
                            generadorBase();
                        } else {
                            Toast.makeText(scanpage.this, "ErroreJson: " + jsonBase.getEsito().getDescrizione(), Toast.LENGTH_SHORT).show();
                        }

                    }

                    @Override
                    public void onError(VolleyError e) {
                        e.printStackTrace();
                    }
                });

            }


        } else {
            Toast.makeText(this, "error da json: " + jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
        }


    }

    public static void raccoglitoreElements(Checklist jsonBase, View Elemento) {
        String tag = Elemento.getTag().toString().replaceAll("\\D", "");

        List<Campi> campi = jsonBase.getPasso().getCampi();

        Campi campoTrovato = null;
        for (Campi campo:
             campi) {
            if (campo.getId().equals(tag)){
                campoTrovato=campo;
                break;
            }
        }


        if (Elemento instanceof EditText) {
            String text = ((EditText) Elemento).getText().toString();
            campoTrovato.setValore(text);
        } else if (Elemento instanceof CheckBox) {
            Boolean value = ((CheckBox) Elemento).isChecked();
            campoTrovato.setValore(value.toString());
        }

    }

    public void raccoglitoreTransizioni(String[] URL, Checklist jsonBase, View btnTransizione, List<View> listaElementi, JsonResponseListener callback) {


        if (btnTransizione instanceof Button) {

            btnTransizione.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    String tag = btnTransizione.getTag().toString().replaceAll("\\D", "");

                    List<Transizioni> transizioni = jsonBase.getPasso().getTransizioni();
                    Transizioni transizioneTrovata = null;

                    for (Transizioni transizione :
                            transizioni) {
                        if (transizione.getId().equals(tag)){
                            transizioneTrovata=transizione;
                            break;
                        }
                    }


                    URL[0] = transizioneTrovata.getUrl();

                    invioRicezioneJson(URL[0], toJsonObject(jsonBase), new JsonResponseListener() {
                        @Override
                        public void onResponse(JSONObject response) {

//                            Il for è necesario perche racoglie le info quando avviene il onclick, attenzione con il jsonbase che verra modificato
                            for (View elemento :
                                    listaElementi) {
                                //Avvio il raccoglitore di info di tutti gli elementi
                                //////////////////////////////////////////////////////
                                raccoglitoreElements(jsonBase, elemento);
                                ///////////////////////
                            }
                            callback.onResponse(response);


                        }

                        @Override
                        public void onError(VolleyError e) {

                            callback.onError(e);

                            Toast.makeText(scanpage.this, "No ha funzionato el boton", Toast.LENGTH_SHORT).show();
                        }
                    });
                }
            });
        }
    }


    private static JSONObject toJsonObject(Checklist checklist) {
        JSONObject jsonObject = null;
        try {
            jsonObject = new JSONObject(GsonSingleton.getGsonInstance().toJson(checklist));
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return jsonObject;
    }

    private void invioRicezioneJson(String URL, JSONObject jsonObject, final JsonResponseListener listener) {
        JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.POST, URL, jsonObject, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                listener.onResponse(response);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError e) {
                Log.e("initMainActivity", "Error en la solicitud: " + e.toString());
                listener.onError(e);
            }
        });

        VolleySingleton.getInstance(this).addToRequestQueue(jsonObjectRequest);
    }

    public interface JsonResponseListener {
        void onResponse(JSONObject response);

        void onError(VolleyError error);
    }


    @Override
    public void onBarcodeEvent(BarcodeReadEvent barcodeReadEvent) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                String scannedData = barcodeReadEvent.getBarcodeData();


                if (!activeEditText.getTag().toString().contains(getResources().getString(R.string.elemento_listacontenitori))) {
                    int cursorPosition = activeEditText.getSelectionStart();
                    String newText = activeEditText.getText().toString().substring(0, cursorPosition) + scannedData + activeEditText.getText().toString().substring(cursorPosition);

                    activeEditText.setText(newText);
                    activeEditText.setSelection(cursorPosition + scannedData.length());


                }
                else if (activeEditText.getTag().toString().contains(getResources().getString(R.string.elemento_listacontenitori))) {
                    LinearLayout parent = (LinearLayout) activeEditText.getParent();
                    boxDati = null;
                    int childCount = parent.getChildCount();
                    for (int i = 0; i < childCount; i++) {
                        View childView = parent.getChildAt(i);
                        if (childView instanceof LinearLayout) {
                            // Si es un LinearLayout, lo asignamos a la variable y salimos del bucle
                            boxDati = (TableLayout) childView;
                            break;
                        }
                    }

                    boxDati.removeAllViews();

                    int id = Integer.parseInt(activeEditText.getTag().toString().replaceAll("\\D", ""));
                    Campi elemento = jsonBase.getPasso().getCampi().get(id);
                    elemento.setValore("");
                    elemento.setValore(scannedData);
                    invioRicezioneJson(elemento.getUrlverifica(), toJsonObject(jsonBase), new JsonResponseListener() {
                        @Override
                        public void onResponse(JSONObject response) {
                            jsonfail = null;
                            jsonfail = GsonSingleton.getGsonInstance().fromJson(response.toString(), Checklist.class);

                            activeEditText.setText("");
                            int colorOriginal = Color.WHITE;
                            if (jsonfail.getEsito().getErrore() == 0) {
                                jsonBase = jsonfail;

                                activeEditText.setText(scannedData);

//                                Animation CheckColor
                                ObjectAnimator colorAnimation = ObjectAnimator.ofObject(activeEditText,"backgroundColor",new ArgbEvaluator(),colorOriginal,getColor(R.color.bombola_trovata));
                                colorAnimation.setDuration(500);
                                colorAnimation.start();
                                new Handler().postDelayed(new Runnable() {
                                    @Override
                                    public void run() {

//                                        Animation backcolor
                                        ObjectAnimator backColorAnimation = ObjectAnimator.ofObject(activeEditText,"backgroundColor",new ArgbEvaluator(),getColor(R.color.bombola_trovata),colorOriginal);
                                        backColorAnimation.setDuration(500);
                                        backColorAnimation.start();
                                    }
                                },1000);


                                Toast.makeText(scanpage.this, "he agregado il view al parent", Toast.LENGTH_SHORT).show();
                            }
                            else {
                                activeEditText.setText(scannedData);
//                                Animation ErrorColor
                                ObjectAnimator colorError = ObjectAnimator.ofObject(activeEditText,"backgroundColor",new ArgbEvaluator(),colorOriginal,getColor(R.color.bombola_non_trovata));
                                colorError.setDuration(500);
                                colorError.start();
                                new Handler().postDelayed(new Runnable() {
                                    @Override
                                    public void run() {
//                                        Animation backcolor
                                        ObjectAnimator backColoAnimation = ObjectAnimator.ofObject(activeEditText,"backgroundColor",new ArgbEvaluator(),getColor(R.color.bombola_non_trovata),colorOriginal);
                                        backColoAnimation.setDuration(500);//spegnimento
                                        backColoAnimation.start();
                                    }
                                },1000);//Tempo che rimane asceso
                                Toast.makeText(scanpage.this, "" + jsonfail.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
                            }


                            for (Chiavi_valori chiave_valore :
                                    jsonBase.getPasso().getCampi().get(id).getChiavi_valori()) {

                                TableRow row = new TableRow(scanpage.this);

                                TextView key = new TextView(scanpage.this);
                                key.setText(chiave_valore.getChiave());
                                key.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.MATCH_PARENT,1));
                                key.setGravity(Gravity.CENTER);
                                key.setBackgroundColor(getColor(R.color.listacontenitori_check_key));


                                TextView valore = new TextView(scanpage.this);
                                valore.setText(chiave_valore.getValore());
                                valore.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.MATCH_PARENT,1));
                                valore.setGravity(Gravity.CENTER);
                                valore.setBackgroundColor(getColor(R.color.listacontenitori_check_valore));

                                row.addView(key);
                                row.addView(valore);

                                boxDati.addView(row);
                            }
                        }

                        @Override
                        public void onError(VolleyError error) {
                            Toast.makeText(scanpage.this, "Errore volley in invio ListaContetori", Toast.LENGTH_LONG).show();
                        }


                    });

                }
            }
        });
    }

    @Override
    public void onFailureEvent(BarcodeFailureEvent barcodeFailureEvent) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {

                Toast.makeText(scanpage.this, "lalalalal", Toast.LENGTH_SHORT).show();
            }
        });

    }


    @Override
    public void onTriggerEvent(TriggerStateChangeEvent triggerStateChangeEvent) {
        try {
            barcodeReader.aim(triggerStateChangeEvent.getState());
            barcodeReader.light(triggerStateChangeEvent.getState());
            barcodeReader.decode(triggerStateChangeEvent.getState());
        } catch (ScannerNotClaimedException e) {
            Toast.makeText(this, "Scanner is not claimed", Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        } catch (ScannerUnavailableException e) {
            Toast.makeText(this, "Scanner unavailable", Toast.LENGTH_SHORT).show();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    @Override
    protected void onResume() {
        super.onResume();
        if (barcodeReader != null) {
            try {
                barcodeReader.claim();
            } catch (ScannerUnavailableException e) {
                e.printStackTrace();
                Toast.makeText(this, "Scanner unavailable", Toast.LENGTH_SHORT).show();
            }
        }
    }

    @Override
    protected void onPause() {
        super.onPause();
        if (barcodeReader != null) {
//            release the scanner claim so we dont get any scanner
//            notifications while paused
            barcodeReader.release();
        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (barcodeReader != null) {
            //unregister barcode event listener
            barcodeReader.removeBarcodeListener(this);
            //unregister trigger state change listener
            barcodeReader.removeTriggerListener(this);
        }
    }

    @Override
    public void onBackPressed() {
        //ho tolto il super per fare in modo che non si possa tornare indietro
    }
}
