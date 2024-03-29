package com.example.solapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;

import com.honeywell.aidc.AidcManager;
import com.honeywell.aidc.BarcodeReader;
import com.honeywell.aidc.InvalidScannerNameException;

public class MainActivity extends AppCompatActivity {

    private static BarcodeReader barcodeReader;
    private AidcManager manager;
    private Button btnScanMe;

    //    getter di BarCodeReader
    static BarcodeReader getBarcodeReader(){
        return barcodeReader;
//        allow other activity to retrieve the barcode reader

    }



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        initComponents();

        Intent barcodeIntent = new Intent(MainActivity.this,scanpage.class);
        startActivity(barcodeIntent);
    }
    private void initComponents() {
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


}