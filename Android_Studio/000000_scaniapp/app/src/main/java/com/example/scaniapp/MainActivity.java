package com.example.scaniapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toolbar;

import com.honeywell.aidc.AidcManager;
import com.honeywell.aidc.BarcodeReader;
import com.honeywell.aidc.InvalidScannerNameException;

public class MainActivity extends AppCompatActivity {

    private static BarcodeReader barcodeReader;
    private AidcManager manager;
    private Button btnScanMe;
    private static String LOG_TAG = "SCANAPP";

//    getter di BarCodeReader
    static BarcodeReader getBarcodeReader(){
        return barcodeReader;
//        allow other activity to retrieve the barcode reader

    }



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initComponents();
        initListeners();

    }

    private void initListeners() {
        btnScanMe.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent barcodeIntent = new Intent("android.intent.action.SCANPAGE");
                startActivity(barcodeIntent);
            }
        });
    }

//è importante perche se non si chiude potrebbe consumare risorse (credo)
    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (barcodeReader != null){
            barcodeReader.close();
            barcodeReader = null;
        }
        if (manager != null){
            manager.close();
        }
    }

    private void initComponents() {
        btnScanMe = findViewById(R.id.btnScanMe);
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
    }
}