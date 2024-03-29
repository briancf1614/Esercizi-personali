package com.example.testgenerator;

import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;

import android.app.Dialog;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.honeywell.aidc.BarcodeFailureEvent;
import com.honeywell.aidc.BarcodeReadEvent;
import com.honeywell.aidc.BarcodeReader;
import com.honeywell.aidc.TriggerStateChangeEvent;
import com.honeywell.aidc.UnsupportedPropertyException;

import java.util.List;
import java.util.Map;
import java.util.Objects;

public class GeneratorActivity extends AppCompatActivity implements BarcodeReader.BarcodeListener, BarcodeReader.TriggerListener {
    private BarcodeReader barcodeReader;
    private EditText etGenerator;
    private Button btnGenerator;
    private CardView cvGenerator;
    private static String Log_TAG = "SCANAPP";
    private EditText activeEditText; // Almacena la referencia al EditText activo

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_generator);
        initComponents();
        initListeners();
    }

    private void initListeners() {
        btnGenerator.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                GeneratorTextView(Integer.parseInt(etGenerator.getText().toString()));
            }
        });

    }

    private void GeneratorTextView(int quantita) {
        Dialog dialog = new Dialog(GeneratorActivity.this);
        dialog.setContentView(R.layout.dialog_generator);
        LinearLayout LinearLayoutGenerator = dialog.findViewById(R.id.LinearLayoutGenerator);
        EditText editText;


        barcodeReader = FirstPageActivity.getBarcodeReader();
        int i;
        if (barcodeReader!=null){
            //            qui gli asegno un listener
            try {
                barcodeReader.setProperty(BarcodeReader.PROPERTY_TRIGGER_CONTROL_MODE,barcodeReader.TRIGGER_CONTROL_MODE_CLIENT_CONTROL);
            } catch (UnsupportedPropertyException e) {
                Toast.makeText(this, "Abbiamo Fallito a configurare le proprietà", Toast.LENGTH_SHORT).show();
            }
            barcodeReader.addTriggerListener(this);
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
                    Toast.makeText(this, "Use system scanning settings", Toast.LENGTH_SHORT).show();
                    break;
                }else {
                    Toast.makeText(this, "Failed import scanner settings. Close app and start again.", Toast.LENGTH_SHORT).show();
                    Log.d(Log_TAG, "barcodeReaderProperties load problem. USe defaults");break;
                }
            }
        }
        for (i = 0; i < quantita; i++) {
            editText = new EditText(GeneratorActivity.this);
            editText.setHint("Hola amigo escrivete algo pe");
//            serve per avviare un listener che selezioni il editText che è selezionato
            editText.setOnFocusChangeListener(new View.OnFocusChangeListener() {
                @Override
                public void onFocusChange(View v, boolean hasFocus) {
                    if (hasFocus && v instanceof EditText) {
                        activeEditText = (EditText) v; // Guardar el EditText activo
                    }
                }
            });


            LinearLayoutGenerator.addView(editText);
        }
        dialog.show();
    }

    private void initComponents() {
        etGenerator = findViewById(R.id.etGenerator);
        btnGenerator = findViewById(R.id.btnGenerator);
        cvGenerator = findViewById(R.id.cvGenerator);
    }


    @Override
    public void onBarcodeEvent(BarcodeReadEvent barcodeReadEvent) {
        Log.d(Log_TAG, "onBarcodeEvent="+barcodeReadEvent.getBarcodeData());
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                Log.d(Log_TAG, "onBarcodeEvent="+barcodeReadEvent.getBarcodeData());
                activeEditText.setText(barcodeReadEvent.getBarcodeData());
            }
        });
    }

    @Override
    public void onFailureEvent(BarcodeFailureEvent barcodeFailureEvent) {

    }

    @Override
    public void onTriggerEvent(TriggerStateChangeEvent triggerStateChangeEvent) {

    }
}