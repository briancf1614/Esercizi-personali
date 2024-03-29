package com.example.solgroup;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.res.AssetManager;
import android.graphics.Typeface;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.VolleyError;
import com.example.solgroup.ChecklistJsonClass.Campi;
import com.example.solgroup.ChecklistJsonClass.Checklist;
import com.example.solgroup.ChecklistJsonClass.Transizioni;
import com.example.solgroup.Singleton.GsonSingleton;
import com.example.solgroup.Singleton.Metods;
import com.honeywell.aidc.AidcManager;
import com.honeywell.aidc.BarcodeFailureEvent;
import com.honeywell.aidc.BarcodeReadEvent;
import com.honeywell.aidc.BarcodeReader;
import com.honeywell.aidc.InvalidScannerNameException;
import com.honeywell.aidc.ScannerUnavailableException;
import com.honeywell.aidc.TriggerStateChangeEvent;
import com.honeywell.aidc.UnsupportedPropertyException;

import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

public class LoginActivity extends AppCompatActivity implements BarcodeReader.BarcodeListener, BarcodeReader.TriggerListener{

    public static Checklist jsonBase;
    private Checklist jsonfail;
    private String[] URL;
    private int esito;
    private LinearLayout linearLayout;
    private LinearLayout elementiLinearLayout;
    private LinearLayout transizioniLinearLayout;
    private List<View> listaElementi = new ArrayList<>();
    private List<View> listaTransizioni = new ArrayList<>();
    public static EditText activeEditText;

    private AidcManager manager;
    private BarcodeReader barcodeReader;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        initComponentBase();
        initLogin();
        generadorBase();


    }

    private void initComponentBase() {

        //Creazione pagina
        linearLayout = new LinearLayout(LoginActivity.this);
        linearLayout.setOrientation(linearLayout.VERTICAL);

///////////////////////////////////////////////////////////
//        qui creo listanza del singleton del AidcMAnager
//////////////////////////////////////////////////////////
        AidcManager.create(this, new AidcManager.CreatedCallback() {
            @Override
            public void onCreated(AidcManager aidcManager) {
                manager = aidcManager;
                try {
                    barcodeReader = manager.createBarcodeReader();
                } catch (InvalidScannerNameException e) {
                    e.printStackTrace();
                }
            }
        });

//        Barcode
        if (barcodeReader!=null){
            //            qui gli asegno un listener
            barcodeReader.addBarcodeListener(LoginActivity.this);
            try {
                barcodeReader.setProperty(BarcodeReader.PROPERTY_TRIGGER_CONTROL_MODE,BarcodeReader.TRIGGER_CONTROL_MODE_CLIENT_CONTROL);
            } catch (UnsupportedPropertyException e) {
                Toast.makeText(this, "Abbiamo Fallito a configurare le proprietà", Toast.LENGTH_LONG).show();
            }
            barcodeReader.addTriggerListener(LoginActivity.this);
            String DEFAULT_PROFILE = "DEFAULT";
            List<String> profiles = this.barcodeReader.getProfileNames();
            Map<String, Object> barcodeReaderProperties = null;

            for (String profile :
                    profiles) {
                if (profile.contains(DEFAULT_PROFILE)&&barcodeReader.loadProfile(profile)){
                    barcodeReaderProperties = barcodeReader.getAllProperties();
                }
                if (barcodeReaderProperties != null && barcodeReaderProperties.size()>0){
                    barcodeReaderProperties.put(BarcodeReader.PROPERTY_CENTER_DECODE,true);
                    barcodeReaderProperties.put(BarcodeReader.PROPERTY_CODE_128_ENABLED,true);
                    barcodeReaderProperties.put(BarcodeReader.PROPERTY_GS1_128_ENABLED,true);
                    barcodeReaderProperties.put(BarcodeReader.PROPERTY_QR_CODE_ENABLED,true);
                    barcodeReaderProperties.put(BarcodeReader.PROPERTY_CODE_39_ENABLED,true);
                    barcodeReader.setProperties(barcodeReaderProperties);///use imported barcode reader properties
                    Toast.makeText(this, "Use system scanning settings", Toast.LENGTH_LONG).show();
                    break;
                }else {
                    Toast.makeText(this, "Failed import scanner settings. Close app and start again.", Toast.LENGTH_LONG).show();
                }
            }
        }
    }

    private void initMenu() {

        esito = jsonBase.getEsito().getErrore();
        if (esito == 0){

            ///////////////////////////
    //      Dentro di raccoglitoreTransizioni avviene il racoglitore di elementi
            for (int i = 0; i < listaTransizioni.size(); i++) {
                Metods.raccoglitoreTransizioni(i, LoginActivity.this, URL, jsonBase, listaTransizioni, listaElementi, new Metods.JsonResponseListener() {
                    @Override
                    public void onResponse(JSONObject response) {
                        if (esito == 0){
                            generadorBase();
                        }
                        else {
                            Toast.makeText(LoginActivity.this, "ErroreJson: " + jsonBase.getEsito().getDescrizione(), Toast.LENGTH_SHORT).show();
                        }

                    }

                    @Override
                    public void onError(VolleyError e) {
                        e.printStackTrace();
                    }
                });
                ///////////////////////////////
            }

        }else {
            Toast.makeText(this, "error da json: "+jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
        }



    }


    //    Metodo exclusivo per il login in quanto viene inserito tutti i metodi utili creati in precedenza
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
        URL[0] = "http://192.168.1.45:7979/ConnettorePDA/IdentificaPDA";
        jsonBase.getPda().setSerial_number("12345678");

    }


    public void generadorBase(){
        esito = jsonBase.getEsito().getErrore();
        if (esito==0){
            Metods.invioRicezioneJson(LoginActivity.this, URL[0], Metods.toJsonObject(jsonBase), new Metods.JsonResponseListener() {
                @Override
                public void onResponse(JSONObject response) {

                    jsonfail = GsonSingleton.getGsonInstance().fromJson(response.toString(), Checklist.class);

                    if (jsonfail.getEsito().getErrore()==0){
    //                jsonBase diventa il nuovo json risposta
                        jsonBase = jsonfail;
                        // Pulire le liste
                        listaElementi.clear();
                        listaTransizioni.clear();

                        linearLayout.removeAllViews();


                        List<Campi> campi = jsonBase.getPasso().getCampi();
                        List<Transizioni> transizioni = jsonBase.getPasso().getTransizioni();

                        elementiLinearLayout = new LinearLayout(LoginActivity.this);
                        elementiLinearLayout.setOrientation(linearLayout.VERTICAL);
                        linearLayout.addView(elementiLinearLayout);
                        for (int i = 0; i < campi.size(); i++) {
                            //////////////////////////////////////////
                            //Genera elementi
                            esito = jsonBase.getEsito().getErrore();
                            if (esito == 0){
                                Metods.generateElemento(LoginActivity.this, listaElementi, campi.get(i), elementiLinearLayout);
                            }else {
                                Toast.makeText(LoginActivity.this, "errore: "+jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
                            }


                        }


                        transizioniLinearLayout = new LinearLayout(LoginActivity.this);
                        transizioniLinearLayout.setOrientation(linearLayout.HORIZONTAL);
                        linearLayout.addView(transizioniLinearLayout);
                        for (int y = 0; y < transizioni.size(); y++) {
                            if (esito == 0){
                                Metods.generateTransizione(LoginActivity.this, listaTransizioni, transizioni.get(y), transizioniLinearLayout);
                            }

                        }

                        setContentView(linearLayout);

                        ////////////////////////////
    //                Bisogna fare attenzione, questo metodo avviene una volta creati tutti i rispettivi elementi o transizioni
                        initMenu();
                        ////////////////////////////
                    }
                    else {
                        Toast.makeText(LoginActivity.this, "ErroreJson: " + jsonfail.getEsito().getDescrizione(), Toast.LENGTH_SHORT).show();
                    }

                }

                @Override
                public void onError(VolleyError e) {
                    e.printStackTrace();
                    Toast.makeText(LoginActivity.this, "volley error, perche ESITO : "+ jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
                }
            });
        }
        else {
            Toast.makeText(this, "error da json: "+jsonBase.getEsito().getDescrizione(), Toast.LENGTH_LONG).show();
        }

    }

    //TODO: Non funziona non so come fare
    @Override
    public void onBarcodeEvent(BarcodeReadEvent barcodeReadEvent) {
        String scannedData = barcodeReadEvent.getBarcodeData();
        activeEditText.setText(scannedData);


        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                Toast.makeText(getApplicationContext(), "lalalaalla", Toast.LENGTH_SHORT).show();
            }
        });


    }


    @Override
    public void onFailureEvent(BarcodeFailureEvent barcodeFailureEvent) {
        Toast.makeText(LoginActivity.this, "uaglio", Toast.LENGTH_SHORT).show();
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                Toast.makeText(LoginActivity.this, "uaglio", Toast.LENGTH_SHORT).show();
            }
        });

    }

    @Override
    public void onTriggerEvent(TriggerStateChangeEvent triggerStateChangeEvent) {
        Toast.makeText(this, "mamma miaaaa", Toast.LENGTH_SHORT).show();
    }



    @Override
    public void onResume() {
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
    public void onPause() {
        super.onPause();
        if (barcodeReader != null) {
            // release the scanner claim so we don't get any scanner
            // notifications while paused.
            barcodeReader.release();
        }
    }


    @Override
    protected void onDestroy() {
        super.onDestroy();

        if (barcodeReader != null) {
            // close BarcodeReader to clean up resources.
            barcodeReader.close();
            barcodeReader = null;
        }

        if (manager != null) {
            // close AidcManager to disconnect from the scanner service.
            // once closed, the object can no longer be used.
            manager.close();
        }
    }
}