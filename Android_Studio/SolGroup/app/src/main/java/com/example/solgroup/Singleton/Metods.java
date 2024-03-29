package com.example.solgroup.Singleton;

import android.content.Context;
import android.graphics.Typeface;
import android.text.InputType;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.example.solgroup.ChecklistJsonClass.Campi;
import com.example.solgroup.ChecklistJsonClass.Checklist;
import com.example.solgroup.ChecklistJsonClass.Chiavi_valori;
import com.example.solgroup.ChecklistJsonClass.Transizioni;
import com.example.solgroup.LoginActivity;
import com.google.gson.Gson;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.List;

public class Metods {

    //    Questo metodo legge il tipo di elemento dentro il json e crea in base a quanto richiesto
    public static void generateElemento(Context context, List<View> listaElementi, Campi elemento, ViewGroup contenitore) {

        if (elemento.getTipo().equals("labeltabellare")){
            LinearLayout LabelTabellare = new LinearLayout(context);
            LabelTabellare.setOrientation(LinearLayout.HORIZONTAL);

            TextView Key = new TextView(context);
            Key.setText(elemento.getMsg());
            Key.setTypeface(null, Typeface.BOLD);
            LabelTabellare.addView(Key);

            TextView Valore = new TextView(context);
            Valore.setText(elemento.getValore());
            Valore.setTag(elemento.getId());
            LabelTabellare.addView(Valore);

            contenitore.addView(LabelTabellare);
        }
        else if (elemento.getTipo().equals("label")){

            TextView Key = new TextView(context);
            Key.setText(elemento.getValore());
            Key.setTypeface(null, Typeface.BOLD);
            Key.setTag(elemento.getId());


            contenitore.addView(Key);

        }
        else if (elemento.getTipo().equals("input")) {
            LinearLayout Input = new LinearLayout(context);
            Input.setOrientation(LinearLayout.VERTICAL);

            TextView tvInput = new TextView(context);
            tvInput.setText(elemento.getMsg());
            Input.addView(tvInput);

            EditText etElemento = new EditText(context);
            etElemento.setHint(elemento.getMsg());
            etElemento.setTag(elemento.getId());

//            Gli aggiungo un listener in modo che appena viene selezionato viene tracciato per il BarcodeReader
            etElemento.setOnFocusChangeListener(new View.OnFocusChangeListener() {
                @Override
                public void onFocusChange(View v, boolean hasFocus) {
                    if (hasFocus && v instanceof EditText) {
                        LoginActivity.activeEditText = (EditText) v; // Guardar el EditText activo
                    }
                }
            });
//            Qua aggiungo a la lista il elemento
            listaElementi.add(etElemento);
            Input.addView(etElemento);

            contenitore.addView(Input);

        }
        else if (elemento.getTipo().equals("password")) {
            LinearLayout Password = new LinearLayout(context);
            Password.setOrientation(LinearLayout.VERTICAL);

            TextView tvPassword = new TextView(context);
            tvPassword.setText(elemento.getMsg());
            Password.addView(tvPassword);

            EditText etPassword = new EditText(context);
            etPassword.setInputType(InputType.TYPE_CLASS_TEXT | InputType.TYPE_TEXT_VARIATION_PASSWORD);
            etPassword.setHint(elemento.getMsg());
            etPassword.setTag(elemento.getId());
//            Qua aggiungo a la lista il elemento
            listaElementi.add(etPassword);
            Password.addView(etPassword);

            contenitore.addView(Password);
        }
        else if (elemento.getTipo().equals("textarea")) {
            LinearLayout TextArea = new LinearLayout(context);
            TextArea.setOrientation(LinearLayout.VERTICAL);

            TextView tvTextArea = new TextView(context);
            tvTextArea.setText(elemento.getMsg());
            TextArea.addView(tvTextArea);

            EditText etTextArea = new EditText(context);
            etTextArea.setHint(elemento.getMsg());
            etTextArea.setTag(elemento.getId());
            etTextArea.setGravity(Gravity.START | Gravity.TOP);
            etTextArea.setInputType(InputType.TYPE_TEXT_FLAG_MULTI_LINE);
            etTextArea.setLines(2);
            etTextArea.setMaxLines(5); // Esto permite un máximo de 10 líneas visibles
            etTextArea.setVerticalScrollBarEnabled(true);
            etTextArea.setHorizontallyScrolling(false);
//            Anche qu i gli aggiungo il scanner nel caso voglia aggiungere il codice come texto
            etTextArea.setOnFocusChangeListener(new View.OnFocusChangeListener() {
                @Override
                public void onFocusChange(View v, boolean hasFocus) {
                    if (hasFocus && v instanceof EditText) {
                        LoginActivity.activeEditText = (EditText) v; // Guardar el EditText activo
                    }
                }
            });

//            Qua aggiungo a la lista il elemento
            listaElementi.add(etTextArea);
            TextArea.addView(etTextArea);

            contenitore.addView(TextArea);

        }
        else if (elemento.getTipo().equals("check")) {

            CheckBox checkBox = new CheckBox(context);
            checkBox.setText(elemento.getMsg());
            checkBox.setTag(elemento.getId());
            checkBox.setChecked(Boolean.parseBoolean(elemento.getValore()));


//            Qua aggiungo a la lista il elemento
            listaElementi.add(checkBox);

            contenitore.addView(checkBox);

        } else if (elemento.getTipo().equals("listacontenitori")) {

            LinearLayout ListaContenitori = new LinearLayout(context);
            ListaContenitori.setOrientation(LinearLayout.VERTICAL);

            TextView tvListaContenitori = new TextView(context);
            tvListaContenitori.setText(elemento.getMsg());
            ListaContenitori.addView(tvListaContenitori);

            LinearLayout boxEtButton = new LinearLayout(context);
            boxEtButton.setOrientation(LinearLayout.HORIZONTAL);

            EditText etListaContenitori = new EditText(context);
            etListaContenitori.setTag(elemento.getId());
            etListaContenitori.setLayoutParams(new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT, 5));
            boxEtButton.addView(etListaContenitori);

            Button btnListaContenitori = new Button(context);
            btnListaContenitori.setText("Checkare");
            btnListaContenitori.setLayoutParams(new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT, 1));


//            Box con tutti gli elementi checkati
            LinearLayout boxCheckato = new LinearLayout(context);
            boxCheckato.setOrientation(LinearLayout.VERTICAL);

            ListaContenitori.addView(boxEtButton);
            ListaContenitori.addView(boxCheckato);
            btnListaContenitori.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    if (!etListaContenitori.getText().toString().isEmpty()){
                        int id = Integer.parseInt(elemento.getId());
                        Campi elementoNuovo = LoginActivity.jsonBase.getPasso().getCampi().get(id);
                        elementoNuovo.setValore("");
                        elementoNuovo.setValore(etListaContenitori.getText().toString());


                        invioRicezioneJson(context, elemento.getUrlverifica(), toJsonObject(LoginActivity.jsonBase), new JsonResponseListener() {
                            @Override
                            public void onResponse(JSONObject response) {
                                Checklist json = null;
                                json = GsonSingleton.getGsonInstance().fromJson(response.toString(),Checklist.class);

                                if (json.getEsito().getErrore()==0){
                                    LoginActivity.jsonBase = json;
                                    boxCheckato.removeAllViews();
                                    for (Chiavi_valori chiave_valore:
                                         json.getPasso().getCampi().get(id).getChiavi_valori()) {


                                        TextView key_valore = new TextView(context);
                                        key_valore.setText(chiave_valore.getChiave()+": " + chiave_valore.getValore());

                                        boxCheckato.addView(key_valore);
                                    }


                                }else {
                                    Toast.makeText(context, "ErroreJson: " + json.getEsito().getDescrizione(), Toast.LENGTH_SHORT).show();
                                }

                            }

                            @Override
                            public void onError(VolleyError error) {

                            }
                        });
                        etListaContenitori.setText("");


                    }
                }
            });
            boxEtButton.addView(btnListaContenitori);


            etListaContenitori.setOnFocusChangeListener(new View.OnFocusChangeListener() {
                @Override
                public void onFocusChange(View v, boolean hasFocus) {
                    if (hasFocus && v instanceof EditText) {
                        LoginActivity.activeEditText = (EditText) v; // Guardar el EditText activo
                    }
                }
            });

            listaElementi.add(etListaContenitori);


            contenitore.addView(ListaContenitori);

        }

    }


    //    Questo metodo legge il tipo di transizione dentro il json e crea in base a quanto richiesto
    public static void generateTransizione(Context context, List<View> listaTransizioni, Transizioni transizioni, ViewGroup contenitore) {

        Button btntransizione = new Button(context);
        btntransizione.setText(transizioni.getMsg());
        btntransizione.setLayoutParams(new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT, 1));
        btntransizione.setTag("id_" + transizioni.getId());
        listaTransizioni.add(btntransizione);

        contenitore.addView(btntransizione);
    }


    //    Questo metodo prende gli elementi creati e aggiunti dentro la lista
    public static void raccoglitoreElements(Checklist jsonBase, View listaElemento ) {
        Campi campo = jsonBase.getPasso().getCampi().get(Integer.parseInt(listaElemento.getTag().toString()));


        if (listaElemento instanceof EditText) {
            String text = ((EditText) listaElemento).getText().toString();
            campo.setValore(text);
        }
        else if (listaElemento instanceof CheckBox) {
            Boolean value = ((CheckBox) listaElemento).isChecked();
            campo.setValore(value.toString());
        }

    }


    //    Questo metodo prende le transizioni create e aggiunti dentro la lista
    public static void raccoglitoreTransizioni(int i, Context context, String[] URL, Checklist jsonBase, List<View> listaTransizioni,List<View> listaElementi, Metods.JsonResponseListener callback) {

        if (listaTransizioni.get(i) instanceof Button) {

            listaTransizioni.get(i).setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Transizioni transizione = jsonBase.getPasso().getTransizioni().get(i);
                    URL[0] = transizione.getUrl();

                    Metods.invioRicezioneJson(context,URL[0], toJsonObject(jsonBase), new Metods.JsonResponseListener() {
                        @Override
                        public void onResponse(JSONObject response) {

//                            Il for è necesario perche racoglie le info quando avviene il onclick, attenzione con il jsonbase che verra modificato
                            for (int i = 0; i < listaElementi.size(); i++) {
                                //Avvio il raccoglitore di info di tutti gli elementi
                                //////////////////////////////////////////////////////
                                raccoglitoreElements(jsonBase, (View) listaElementi.get(i));
                                ///////////////////////
                            }
                            callback.onResponse(response);


                        }

                        @Override
                        public void onError(VolleyError e) {

                            callback.onError(e);

                            Toast.makeText(context, "No ha funzionato el boton", Toast.LENGTH_SHORT).show();
                        }
                    });
                }
            });
        }
    }


    //    Questo metodo serve per inviare una json e ricevere un json come risposta,Bisogna personalizzare il listener appena
    //    viene chiamato va configurato per decidere cosa fare con la risposta
    public static void invioRicezioneJson(Context context, String URL, JSONObject jsonObject, final Metods.JsonResponseListener listener) {
        JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.POST, URL, jsonObject, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                listener.onResponse(response);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError e) {
                Log.e("initLoginActivity", "Error en la solicitud: " + e.toString());
                listener.onError(e);
            }
        });

        VolleySingleton.getInstance(context).addToRequestQueue(jsonObjectRequest);
    }


    //    Interfaccia utile per modificare a piacimento i jsonresponselistener
    public interface JsonResponseListener {
        void onResponse(JSONObject response);

        void onError(VolleyError error);
    }


    //    Questo metodo transforma un gson in jsonobject per spedirlo tramite jsonResponse
    public static JSONObject toJsonObject(Checklist checklist) {
        JSONObject jsonObject = null;
        try {
            jsonObject = new JSONObject(GsonSingleton.getGsonInstance().toJson(checklist));
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return jsonObject;
    }


}
