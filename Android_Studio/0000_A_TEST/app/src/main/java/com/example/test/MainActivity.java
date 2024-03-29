package com.example.test;

import android.app.Activity;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.os.Build;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.honeywell.aidc.AidcManager;
import com.honeywell.aidc.AidcManager.CreatedCallback;
import com.honeywell.aidc.BarcodeReader;
import com.honeywell.aidc.InvalidScannerNameException;

public class MainActivity extends AppCompatActivity {

    ///////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////
//    TODO: Controlar  bien el manifest porque da errores raros, ademas controlar tambien en onbarread si metes el toast fuera no funciona el metodo
    //////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////

    private static BarcodeReader barcodeReader;
    private AidcManager manager;

    private Button btnAutomaticBarcode;
    private Button btnClientBarcode;
    private Button btnScannerSelectBarcode;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        if(Build.MODEL.startsWith("VM1A")) {
            setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
        }
        else{
            setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
        }

        // create the AidcManager providing a Context and a
        // CreatedCallback implementation.
        AidcManager.create(this, new CreatedCallback() {

            @Override
            public void onCreated(AidcManager aidcManager) {
                manager = aidcManager;
                try{
                    barcodeReader = manager.createBarcodeReader();
                }
                catch (InvalidScannerNameException e){
                    Toast.makeText(MainActivity.this, "Invalid Scanner Name Exception: " + e.getMessage(), Toast.LENGTH_SHORT).show();
                }
                catch (Exception e){
                    Toast.makeText(MainActivity.this, "Exception: " + e.getMessage(), Toast.LENGTH_SHORT).show();
                }
            }
        });

        ActivitySetting();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.activity_main, menu);
        return true;
    }

    static BarcodeReader getBarcodeObject() {
        return barcodeReader;
    }

    /**
     * Create buttons to launch demo activities.
     */
    public void ActivitySetting() {
        btnAutomaticBarcode = (Button) findViewById(R.id.buttonAutomaticBarcode);
        btnAutomaticBarcode.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // get the intent action string from AndroidManifest.xml
                Intent barcodeIntent = new Intent(MainActivity.this,AutomaticBarcodeActivity.class);
                startActivity(barcodeIntent);
            }
        });

        btnClientBarcode = (Button) findViewById(R.id.buttonClientBarcode);
        btnClientBarcode.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // get the intent action string from AndroidManifest.xml
                Intent barcodeIntent = new Intent(MainActivity.this,ClientBarcodeActivity.class);
                startActivity(barcodeIntent);
            }
        });

        btnScannerSelectBarcode = (Button) findViewById(R.id.buttonScannerSelectBarcode);
        btnScannerSelectBarcode.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // get the intent action string from AndroidManifest.xml
                Intent barcodeIntent = new Intent(
                        MainActivity.this,ScannerSelectionBarcodeActivity.class);
                startActivity(barcodeIntent);
            }
        });
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
