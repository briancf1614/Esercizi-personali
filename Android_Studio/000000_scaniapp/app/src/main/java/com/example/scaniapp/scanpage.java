package com.example.scaniapp;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;
import android.widget.Toast;

import com.honeywell.aidc.BarcodeFailureEvent;
import com.honeywell.aidc.BarcodeReadEvent;
import com.honeywell.aidc.BarcodeReader;
import com.honeywell.aidc.ScannerNotClaimedException;
import com.honeywell.aidc.ScannerUnavailableException;
import com.honeywell.aidc.TriggerStateChangeEvent;
import com.honeywell.aidc.UnsupportedPropertyException;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;

public class scanpage extends AppCompatActivity implements BarcodeReader.BarcodeListener, BarcodeReader.TriggerListener{

    private BarcodeReader barcodeReader;
    private TextView tvScan;
    private static String Log_TAG = "SCANAPP";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_scanpage);
        initComponents();
    }

    private void initComponents() {
        tvScan = findViewById(R.id.tvscan);

        ////////////////////////////////
        //Settaggio del barcodeReader
        ////////////////////////////////

        barcodeReader = MainActivity.getBarcodeReader();
        if (barcodeReader != null){


            //TODO: Importatne questa parte, mi ha fatto sclerare perche se questo non cè lo scanner funziona, ma non fa avviare i listeners PTM :(
//            qui gli asegno un listener
            barcodeReader.addBarcodeListener(this);


//            qui do controllo di attivare lo scanner(no obligatoriamente con pulsante fisico)
            try {
                barcodeReader.setProperty(BarcodeReader.PROPERTY_TRIGGER_CONTROL_MODE,BarcodeReader.TRIGGER_CONTROL_MODE_CLIENT_CONTROL);
            }
            catch (UnsupportedPropertyException e){
                Toast.makeText(this, "Failed a aplicar las propiedades pappu ", Toast.LENGTH_SHORT).show();
            }
//            qua meto un listener del pulsante avviatore di scanner( pulsante fisico)
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
            // Disable bad read response, handle in onFailureEvent
            properties.put(BarcodeReader.PROPERTY_NOTIFICATION_BAD_READ_ENABLED, false);
            // Sets time period for decoder timeout in any mode
            properties.put(BarcodeReader.PROPERTY_DECODER_TIMEOUT,  400);
            // Apply the settings
            barcodeReader.setProperties(properties);
        }
            }

    @Override
    public void onBarcodeEvent(BarcodeReadEvent barcodeReadEvent) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                Log.d(Log_TAG, "onBarcodeEvent="+barcodeReadEvent.getBarcodeData());
                tvScan.setText(barcodeReadEvent.getBarcodeData());
            }
        });
    }

    @Override
    public void onFailureEvent(BarcodeFailureEvent barcodeFailureEvent) {
        Log.i(Log_TAG, "No decode - " + barcodeFailureEvent.toString());
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                tvScan.setText("No decode");
            }
        });

    }



    @Override
    public void onTriggerEvent(TriggerStateChangeEvent triggerStateChangeEvent) {
        try {
            barcodeReader.aim(triggerStateChangeEvent.getState());
            barcodeReader.light(triggerStateChangeEvent.getState());
            barcodeReader.decode(triggerStateChangeEvent.getState());
        }catch (ScannerNotClaimedException e){
            Toast.makeText(this, "Scanner is not claimed", Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }catch (ScannerUnavailableException e){
            Toast.makeText(this, "Scanner unavailable", Toast.LENGTH_SHORT).show();
        }catch (Exception e){
            e.printStackTrace();
        }
    }


    @Override
    protected void onResume() {
        super.onResume();
        if (barcodeReader != null){
            try {
                barcodeReader.claim();
            }catch(ScannerUnavailableException e){
                e.printStackTrace();
                Toast.makeText(this, "Scanner unavailable", Toast.LENGTH_SHORT).show();
            }
        }
    }

    @Override
    protected void onPause() {
        super.onPause();
        if (barcodeReader != null){
//            release the scanner claim so we dont get any scanner
//            notifications while paused
            barcodeReader.release();
        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (barcodeReader!=null){
            //unregister barcode event listener
            barcodeReader.removeBarcodeListener(this);
            //unregister trigger state change listener
            barcodeReader.removeTriggerListener(this);
        }
    }
}
