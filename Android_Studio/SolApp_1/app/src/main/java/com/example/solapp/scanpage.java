package com.example.solapp;

import android.animation.ArgbEvaluator;
import android.animation.ObjectAnimator;
import android.app.AlertDialog;
import android.app.PendingIntent;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.res.AssetManager;
import android.graphics.Color;
import android.graphics.Typeface;
import android.graphics.drawable.ColorDrawable;
import android.graphics.drawable.Drawable;
import android.nfc.NfcAdapter;
import android.nfc.Tag;
import android.nfc.tech.IsoDep;
import android.nfc.tech.MifareClassic;
import android.nfc.tech.MifareUltralight;
import android.nfc.tech.Ndef;
import android.nfc.tech.NfcA;
import android.nfc.tech.NfcB;
import android.nfc.tech.NfcF;
import android.nfc.tech.NfcV;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.provider.Settings;
import android.text.InputType;
import android.util.Log;
import android.util.TypedValue;
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
import com.example.solapp.SQLite.Entity.LogEntity;
import com.example.solapp.SQLite.Interfaccia.DaoLogEntity;
import com.example.solapp.SQLite.MyRoomDatabase;
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
import java.sql.Timestamp;
import java.time.Instant;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.Scanner;

public class scanpage extends AppCompatActivity implements BarcodeReader.BarcodeListener, BarcodeReader.TriggerListener {

    MyRoomDatabase database ;
    DaoLogEntity daoLogEntity ;
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
    private NfcAdapter nfcAdapter;
    private TableLayout boxDati;

    private final String[][] techList = new String[][]{
            new String[]{
                    NfcA.class.getName(),
                    NfcB.class.getName(),
                    NfcF.class.getName(),
                    NfcV.class.getName(),
                    IsoDep.class.getName(),
                    MifareClassic.class.getName(),
                    MifareUltralight.class.getName(), Ndef.class.getName()
            }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        database = MyRoomDatabase.getDatabase(this);
        daoLogEntity = database.daoLogEntity();

        setBarcodeReader();
        activateNFC();
        generateLinearLayout();
        initLogin();
        generadorBase();
    }

    private void setBarcodeReader() {
        try {
            insertDB("setBarcodeReader: ", "Sono riuscito a ottenere dal main il barcodeReader",null);
            barcodeReader = MainActivity.getBarcodeReader();
        } catch (Exception e) {
            insertDB("setBarcodeReader: ", "Non sono riuscito a ottenere dal main il barcodeReader",e.getMessage());
        }


        ///////////////////////////////////////////////////////////
        //qui creo listanza del singleton del AidcMAnager
        //////////////////////////////////////////////////////////

//        Barcode
        if (barcodeReader != null) {
            //            qui gli asegno un listener
            barcodeReader.addBarcodeListener(this);
            insertDB("setBarcodeReader ", "Ho aggiunto il BarcodeListener", null);
            try {
                insertDB("setBarcodeReader: ", "Settaggio delle proprietà di scan barcode QR", null);
                barcodeReader.setProperty(BarcodeReader.PROPERTY_TRIGGER_CONTROL_MODE, BarcodeReader.TRIGGER_CONTROL_MODE_CLIENT_CONTROL);
            } catch (UnsupportedPropertyException e) {
                Log.e("setBarcodeReader: ", "Cè un problema con il settagio dello scan");
                Toast.makeText(this, "Abbiamo Fallito a configurare le proprietà", Toast.LENGTH_LONG).show();
            }
            barcodeReader.addTriggerListener(this);
            insertDB("setBarcodeReader ", "Ho aggiunto il TriggerListener", null);

            Map<String, Object> properties = new HashMap<String, Object>();
            try {
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
            } catch (Exception e) {
                Log.e("setBarcodeReader ", "Non sono riuscito a settare corretamente le proprieta del Barcode",e);
            }


        }
    }

    private void activateNFC() {
        insertDB("activateNFC: ", "Controllo NFC On/Off", null);
        NfcAdapter oNfcAdapter = NfcAdapter.getDefaultAdapter(this);
        if (!oNfcAdapter.isEnabled()) {
            insertDB("activateNFC: ", "Non è attivo il NFC", null);
            AlertDialog.Builder alertbox = new AlertDialog.Builder(this);
            alertbox.setTitle("Info");
            alertbox.setMessage("Abilita NFC");
            alertbox.setPositiveButton("Turn On", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    insertDB("activateNFC: ", "Hai deciso di attivare il NFC", null);
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.JELLY_BEAN) {
                        Intent intent = new Intent(Settings.ACTION_NFC_SETTINGS);
                        startActivity(intent);
                    } else {
                        Intent intent = new Intent(Settings.ACTION_WIRELESS_SETTINGS);
                        startActivity(intent);
                    }
                }
            });
            alertbox.setNegativeButton("Close", new DialogInterface.OnClickListener() {

                @Override
                public void onClick(DialogInterface dialog, int which) {

                    insertDB("activateNFC: ", "Hai deciso di NON attivare il NFC", null);
                }
            });
            alertbox.show();
        }


    }

    private void generateLinearLayout() {
        try {
            linearLayout = new LinearLayout(this);
            linearLayout.setOrientation(linearLayout.VERTICAL);
            ScrollView vistaPrincipale = new ScrollView(scanpage.this);
            vistaPrincipale.addView(linearLayout);
            setContentView(vistaPrincipale);
            insertDB("generateLinearLayout: ", "é stato creato il LinearLayout Padre", null);
        } catch (Exception e) {
            Log.e("generateLinearLayout", "Non sono stato in grado di realizzare il LinearLayout",e);
        }

    }

    private void initLogin() {
//        Leggo il json in assets
        AssetManager assetManager = getAssets();
        try (InputStream inputStream = assetManager.open("Checklist.json")) {

            String string_json_Base = new Scanner(inputStream).useDelimiter("\\A").next();
            jsonBase = GsonSingleton.getGsonInstance().fromJson(string_json_Base, Checklist.class);
            insertDB("initLogin: ", "Sto scrivendo il primo jsonBase", null);
        } catch (IOException e) {
            Toast.makeText(this, "C'è un problemmino con il json BASE, o non sono riuscito a leggerlo", Toast.LENGTH_LONG).show();
            insertDB("initLogin: ", "Non sono riuscito a ottenere il primo jsonBase", null);
        }

//        Lo inserisco in un array per fare in modo che al chiamarlo dopo dentro qualche metodo, non mi crei una copia, ma mi passi diretamente il riferimento al array
        URL = new String[1];
        URL[0] = "https://connettorepda.syncpointweb.it/ConnettorePDA/IdentificaPDA";
        jsonBase.getPda().setSerial_number("12345678");
    }

    private void generadorBase() {
        try {
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
                                Toast.makeText(scanpage.this, "Non ho genereato l'elemento J: " + jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
                            }
                        }
                        transizioniLinearLayout = new LinearLayout(scanpage.this);
                        transizioniLinearLayout.setOrientation(linearLayout.VERTICAL);
                        linearLayout.addView(transizioniLinearLayout);


                        for (Transizioni transizione :
                                transizioni) {
                            if (esito == 0) {
                                generateTransizione(listaTransizioni, transizione, transizioniLinearLayout);
                            }
                        }


                        ////////////////////////////
                        //                Bisogna fare attenzione, questo metodo avviene una volta creati tutti i rispettivi elementi o transizioni

                        ////////////////////////////
                    } else {
                        Toast.makeText(scanpage.this, "ErroreJson: " + jsonfail.getEsito().getDescrizione(), Toast.LENGTH_SHORT).show();
                    }

                }

                @Override
                public void onError(VolleyError e) {
                    Log.e("generadorBase: ", "Errore nella chiamata InvioRicezioneJson",e);
                    Toast.makeText(scanpage.this, "volley error, perche ESITO : " + jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
                }
            });



        } catch (Exception e) {
            Log.e("generadorBase: ","Cè stato un problema dentro il try",e);
        }


    }

    private void applyTextViewStyles(TextView textView, String[] styles) {
        try {
            insertDB("applyStyle: ", "Aplicando stilo al TextView", null);
            for (int i = 0; i < styles.length; i++) {
                if (textView != null && i == 0) {
//                    textView.setForeground(new ColorDrawable(Color.parseColor(styles[0])));//TODO: Chiedere se è giusto background e foreground, perche è diverso nella app e nel simulatore
                    textView.setBackgroundColor(Color.parseColor(styles[0]));
                } else if (textView != null && i == 1) {
//                    textView.setBackgroundColor(Color.parseColor(styles[1]));
                    textView.setTextColor(Color.parseColor(styles[1]));
                } else if (textView != null && i == 2) {
                    textView.setTypeface(Typeface.create(styles[2], Typeface.NORMAL));
                } else if (textView != null && i == 3) {//TODO: Controllare con i tipi di family, potrebbe essere che non è installato nel dispositivo
                    textView.setTextSize(TypedValue.COMPLEX_UNIT_SP, Integer.parseInt(styles[3]));
                } else if (textView != null && i == 4) {
                    if (Boolean.parseBoolean(styles[4])) {
                        textView.setTypeface(null, Typeface.BOLD);
                    }
                } else if (textView != null && i == 5) {
                    if (Boolean.parseBoolean(styles[5])) {
                        textView.setTypeface(null, Typeface.ITALIC);
                    }
                }


            }
        } catch (NumberFormatException e) {
            Log.e("applyTextViewStyles: ", "Cè stato un problema con styles",e);
        }
    }

    private void applyEditTextStyles(EditText editText, String[] styles) {
        try {
            insertDB("applyStyle: ", "Aplicando stilo al TextView", null);
            for (int i = 0; i < styles.length; i++) {
                if (editText != null && i == 0) {
//                    editText.setForeground(new ColorDrawable(Color.parseColor(styles[0])));//TODO: Chiedere se è giusto background e foreground, perche è diverso nella app e nel simulatore
                    editText.setBackgroundColor(Color.parseColor(styles[0]));
                } else if (editText != null && i == 1) {
//                    editText.setBackgroundColor(Color.parseColor(styles[1]));
                    editText.setTextColor(Color.parseColor(styles[1]));
                } else if (editText != null && i == 2) {
                    editText.setTypeface(Typeface.create(styles[2], Typeface.NORMAL));
                } else if (editText != null && i == 3) {//TODO: Controllare con i tipi di family, potrebbe essere che non è installato nel dispositivo
                    editText.setTextSize(TypedValue.COMPLEX_UNIT_SP, Integer.parseInt(styles[3]));
                } else if (editText != null && i == 4) {
                    if (Boolean.parseBoolean(styles[4])) {
                        editText.setTypeface(null, Typeface.BOLD);
                    }
                } else if (editText != null && i == 5) {
                    if (Boolean.parseBoolean(styles[5])) {
                        editText.setTypeface(null, Typeface.ITALIC);
                    }
                }


            }
        } catch (NumberFormatException e) {
            Log.e("applyTextViewStyles: ", "Cè stato un problema con styles",e);
        }
    }

    private void applyCheckBoxStyles(CheckBox checkBox, String[] styles) {
        try {
            insertDB("applyStyle: ", "Aplicando stilo al TextView", null);
            for (int i = 0; i < styles.length; i++) {
                if (checkBox != null && i == 0) {
//                    checkBox.setForeground(new ColorDrawable(Color.parseColor(styles[0])));//TODO: Chiedere se è giusto background e foreground, perche è diverso nella app e nel simulatore
                    checkBox.setBackgroundColor(Color.parseColor(styles[0]));
                } else if (checkBox != null && i == 1) {
//                    checkBox.setBackgroundColor(Color.parseColor(styles[1]));
                    checkBox.setTextColor(Color.parseColor(styles[1]));
                } else if (checkBox != null && i == 2) {
                    checkBox.setTypeface(Typeface.create(styles[2], Typeface.NORMAL));
                } else if (checkBox != null && i == 3) {//TODO: Controllare con i tipi di family, potrebbe essere che non è installato nel dispositivo
                    checkBox.setTextSize(TypedValue.COMPLEX_UNIT_SP, Integer.parseInt(styles[3]));
                } else if (checkBox != null && i == 4) {
                    if (Boolean.parseBoolean(styles[4])) {
                        checkBox.setTypeface(null, Typeface.BOLD);
                    }
                } else if (checkBox != null && i == 5) {
                    if (Boolean.parseBoolean(styles[5])) {
                        checkBox.setTypeface(null, Typeface.ITALIC);
                    }
                }


            }
        } catch (NumberFormatException e) {
            Log.e("applyTextViewStyles: ", "Cè stato un problema con styles",e);
        }
    }

    private void applyButtonStyles(Button button, String[] styles) {
        try {
            insertDB("applyButtonStyles: ", "Aplicando stilo al Button", null);
            for (int i = 0; i < styles.length; i++) {
                if (button != null && i == 0) {
//                    checkBox.setForeground(new ColorDrawable(Color.parseColor(styles[0])));//TODO: Chiedere se è giusto background e foreground, perche è diverso nella app e nel simulatore
                    button.setBackgroundColor(Color.parseColor(styles[0]));
                } else if (button != null && i == 1) {
//                    button.setBackgroundColor(Color.parseColor(styles[1]));
                    button.setTextColor(Color.parseColor(styles[1]));
                } else if (button != null && i == 2) {
                    button.setTypeface(Typeface.create(styles[2], Typeface.NORMAL));
                } else if (button != null && i == 3) {//TODO: Controllare con i tipi di family, potrebbe essere che non è installato nel dispositivo
                    button.setTextSize(TypedValue.COMPLEX_UNIT_SP, Integer.parseInt(styles[3]));
                } else if (button != null && i == 4) {
                    if (Boolean.parseBoolean(styles[4])) {
                        button.setTypeface(null, Typeface.BOLD);
                    }
                } else if (button != null && i == 5) {
                    if (Boolean.parseBoolean(styles[5])) {
                        button.setTypeface(null, Typeface.ITALIC);
                    }
                }


            }
        } catch (NumberFormatException e) {
            Log.e("applyTextViewStyles: ", "Cè stato un problema con styles",e);
        }
    }


    private void applyStyle(View elemento, String[] styles) {
        if (elemento != null && styles != null && styles.length > 0) {
            if (elemento instanceof TextView) {
                TextView textView = (TextView) elemento;
                applyTextViewStyles(textView, styles);
            } else if (elemento instanceof EditText) {
                EditText editText = (EditText) elemento;
                applyEditTextStyles(editText, styles);
            } else if (elemento instanceof CheckBox) {
                CheckBox checkBox = (CheckBox) elemento;
                applyCheckBoxStyles(checkBox, styles);
            } else if (elemento instanceof Button) {
                Button button = (Button) elemento;
                applyButtonStyles(button, styles);
            }
            // Puedes agregar más condiciones para otros tipos de vistas que necesites manejar
        } else {
            Log.e("applyStyle: ", "Cè un errore con lelemento ricevuto, oppure con la stringa style, la quale è vuota");
        }
    }


    private void generateElemento(Context context, List<View> listaElementi, Campi elemento, ViewGroup contenitore) {

        String[] styleLabel = (elemento.getStylelabel() != null && !elemento.getStylelabel().isEmpty()) ? elemento.getStylelabel().split(","): new String[0];
        String[] styleValore = (elemento.getStylevalue() !=null && !elemento.getStylevalue().isEmpty()) ? elemento.getStylevalue().split(","): new String[0];

        if (styleLabel.length > 0 && styleValore.length > 0) {
            insertDB("generateElemento: ", "Sono riuscito a deserializzare la stringa degli style del elemento: " + elemento.getTipo(), null);
        } else {
            Log.e("generateElemento: ", "Non sono riuscito a creare gli array degli style del elemento: " + elemento.getTipo());
        }



        /*
         * I listener permettono di farli modificabili tramite scanner
         * Ogni elemento(se neccesario) ha settato come tag il idCampo, il quale facilita la modifica nella logica
         * Per facilitare il cambiamento dei nomi degli elementi i nomi si trovano in values/strings.xml, in quel modo bisognera solo cambiare i nomi in quel file
         */

        if (elemento.getTipo().equals(getResources().getString(R.string.elemento_labeltabellare))) {

            TableRow row = new TableRow(context);
            row.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 1));

            TextView Key = new TextView(context);
            applyStyle(Key, styleLabel);
            Key.setText(elemento.getMsg());

            Key.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 1));
            row.addView(Key);

            TextView Valore = new TextView(context);
            applyStyle(Valore, styleValore);
            Valore.setText(elemento.getValore());
            Valore.setTag(elemento.getId() + getResources().getString(R.string.elemento_labeltabellare));
            Valore.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 3));
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

    private void generateTransizione(List<View> listaTransizioni, Transizioni transizioni, ViewGroup contenitore) {

        String[] styleTransizioni = (transizioni.getStyle()!=null && !transizioni.getStyle().isEmpty()) ? transizioni.getStyle().split(","): new String[0];

        if (styleTransizioni.length > 0 && styleTransizioni.length > 0) {
            insertDB("generateTransizione: ", "Sono riuscito a deserializzare la stringa degli style della transizione: "+transizioni.getMsg(), null);
        } else {
            Log.e("generateElemento: ", "Non sono riuscito a creare gli array dello style della transizione: : " + transizioni.getMsg());
        }


        Button btntransizione = new Button(this);
        applyStyle(btntransizione, styleTransizioni);
        btntransizione.setText(transizioni.getMsg());
        btntransizione.setLayoutParams(new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT, 1));
        btntransizione.setTag(transizioni.getId());
        btntransizione.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //                            Il for è necesario perche racoglie le info quando avviene il onclick, attenzione con il jsonBase che verra modificato
                for (View elemento :
                        listaElementi) {
                    //Avvio il raccoglitore di info di tutti gli elementi
                    //////////////////////////////////////////////////////
                    raccoglitoreElements(jsonBase, elemento);
                    ///////////////////////
                }


                String tag = btntransizione.getTag().toString().replaceAll("\\D", "");

                List<Transizioni> transizioni = jsonBase.getPasso().getTransizioni();
                Transizioni transizioneTrovata = null;

                try {
                    for (Transizioni transizione :
                            transizioni) {
                        if (transizione.getId().equals(tag)) {
                            transizioneTrovata = transizione;
                            insertDB("raccoglitoreTransizioni: ", "Sto cercando la transizione della lista nella transizione del jsonbase", null);
                            break;
                        }
                    }


                    URL[0] = transizioneTrovata.getUrl();
                    insertDB("raccoglitoreTransizioni: ", "Transizione trovata e conessa al jsonBase con URL: " + URL[0], null);

                    initMenu();
                } catch (Exception e) {
                    Log.e("raccoglitoreTransizioni: ", "Non sono riuscito a connettere la transizione con il jsonBase",e);
                }


            }
        });


        listaTransizioni.add(btntransizione);


        contenitore.addView(btntransizione);
    }

    private void initMenu() {

        esito = jsonBase.getEsito().getErrore();
        if (esito == 0) {

            generadorBase();


        } else {
            Toast.makeText(this, "error da json: " + jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
        }


    }

    private void raccoglitoreElements(Checklist jsonBase, View Elemento) {
        String tag = Elemento.getTag().toString().replaceAll("\\D", "");

        List<Campi> campi = jsonBase.getPasso().getCampi();

        Campi campoTrovato = null;
        try {
            for (Campi campo :
                    campi) {
                if (campo.getId().equals(tag)) {
                    campoTrovato = campo;
                    insertDB("raccoglitoreElements: ", "Sto cercando il campo della lista nei del jsonbase", null);
                    break;
                }
            }
            if (Elemento instanceof EditText) {
                insertDB("raccoglitoreElements: ", "Elemento connesso al jsonBase", null);
                String text = ((EditText) Elemento).getText().toString();
                campoTrovato.setValore(text);
            } else if (Elemento instanceof CheckBox) {
                insertDB("raccoglitoreElements: ", "Elemento connesso al jsonBase", null);
                Boolean value = ((CheckBox) Elemento).isChecked();
                campoTrovato.setValore(value.toString());
            }


        } catch (Exception e) {
            Log.e("raccoglitoreElements: ", "Non sono riuscito a connetere il campo con il jsonBase" + e.getMessage());
        }

    }

    private static JSONObject toJsonObject(Checklist checklist) {
        JSONObject jsonObject = null;
        try {
            jsonObject = new JSONObject(GsonSingleton.getGsonInstance().toJson(checklist));
        } catch (JSONException e) {
            Log.e("toJsonObject", "toJsonObject: ",e);
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

    private interface JsonResponseListener {
        void onResponse(JSONObject response);

        void onError(VolleyError error);
    }


    //    Esta seccion serve per trasformare i bytes in dati
    private String bytesToHexString(byte[] src) {
        StringBuilder stringBuilder = new StringBuilder();
        if (src == null || src.length <= 0) {
            return null;
        }
        for (byte b : src) {
            int v = b & 0xFF;
            String hexString = Integer.toHexString(v);
            if (hexString.length() < 2) {
                stringBuilder.append(0);
            }
            stringBuilder.append(hexString.toUpperCase());
        }
        return stringBuilder.toString();
    }



    private void insertDB(String LogKey,String LogData,String Error){
        new AsyncTask<Void,Void,Void>(){
            @Override
            protected Void doInBackground(Void... voids) {

                LogEntity log = new LogEntity();
                log.setTimestamp(Timestamp.from(Instant.now()).toInstant().toString());
                log.setLogKey(LogKey);
                log.setLogData(LogData);
                log.setError(Error);
                log.setIserror((Error == null) ? false : true);

                daoLogEntity.insertData(log);
                return null;
            }

        }.execute();
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


                } else if (activeEditText.getTag().toString().contains(getResources().getString(R.string.elemento_listacontenitori))) {
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
                                ObjectAnimator colorAnimation = ObjectAnimator.ofObject(activeEditText, "backgroundColor", new ArgbEvaluator(), colorOriginal, getColor(R.color.bombola_trovata));
                                colorAnimation.setDuration(500);
                                colorAnimation.start();
                                new Handler().postDelayed(new Runnable() {
                                    @Override
                                    public void run() {

//                                        Animation backcolor
                                        ObjectAnimator backColorAnimation = ObjectAnimator.ofObject(activeEditText, "backgroundColor", new ArgbEvaluator(), getColor(R.color.bombola_trovata), colorOriginal);
                                        backColorAnimation.setDuration(500);
                                        backColorAnimation.start();
                                    }
                                }, 1000);


                                Toast.makeText(scanpage.this, "he agregado il view al parent", Toast.LENGTH_SHORT).show();
                            } else {
                                activeEditText.setText(scannedData);
//                                Animation ErrorColor
                                ObjectAnimator colorError = ObjectAnimator.ofObject(activeEditText, "backgroundColor", new ArgbEvaluator(), colorOriginal, getColor(R.color.bombola_non_trovata));
                                colorError.setDuration(500);
                                colorError.start();
                                new Handler().postDelayed(new Runnable() {
                                    @Override
                                    public void run() {
//                                        Animation backcolor
                                        ObjectAnimator backColoAnimation = ObjectAnimator.ofObject(activeEditText, "backgroundColor", new ArgbEvaluator(), getColor(R.color.bombola_non_trovata), colorOriginal);
                                        backColoAnimation.setDuration(500);//spegnimento
                                        backColoAnimation.start();
                                    }
                                }, 1000);//Tempo che rimane asceso
                                Toast.makeText(scanpage.this, "" + jsonfail.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
                            }


                            for (Chiavi_valori chiave_valore :
                                    jsonBase.getPasso().getCampi().get(id).getChiavi_valori()) {

                                TableRow row = new TableRow(scanpage.this);

                                TextView key = new TextView(scanpage.this);
                                key.setText(chiave_valore.getChiave());
                                key.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.MATCH_PARENT, 1));
                                key.setGravity(Gravity.CENTER);
                                key.setBackgroundColor(getColor(R.color.listacontenitori_check_key));


                                TextView valore = new TextView(scanpage.this);
                                valore.setText(chiave_valore.getValore());
                                valore.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.MATCH_PARENT, 1));
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
                Toast.makeText(scanpage.this, "Nessun dato scanerizzato", Toast.LENGTH_SHORT).show();
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

//        NFC
        PendingIntent pendingIntent = PendingIntent.getActivity(this, 0, new Intent(this, getClass()).addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP), 0);
        IntentFilter filter = new IntentFilter();
        filter.addAction(NfcAdapter.ACTION_TAG_DISCOVERED);
        NfcAdapter nfcAdapter = NfcAdapter.getDefaultAdapter(this);
        nfcAdapter.enableForegroundDispatch(this, pendingIntent, new IntentFilter[]{filter}, this.techList);

    }

    @Override
    protected void onPause() {
        super.onPause();
        if (barcodeReader != null) {
//            release the scanner claim so we dont get any scanner
//            notifications while paused
            barcodeReader.release();
        }

//        NFC
        if (nfcAdapter != null) {
            nfcAdapter.disableForegroundDispatch(this);
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
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        if (NfcAdapter.ACTION_TAG_DISCOVERED.equals(intent.getAction())) {
            Tag tag = intent.getParcelableExtra(NfcAdapter.EXTRA_TAG);
            byte[] id = tag.getId();
            String hexId = bytesToHexString(id);
            for (View elemento :
                    listaElementi) {
                if (elemento.getTag().toString().contains(getResources().getString(R.string.elemento_password))) {
                    EditText password = (EditText) elemento;
                    password.setText(hexId);
                    Button bottone = (Button) listaTransizioni.get(0);
                    bottone.performClick();
                }
            }
        }
    }

    @Override
    public void onBackPressed() {
        //ho tolto il super per fare in modo che non si possa tornare indietro
    }
}
