package com.example.solconnect;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.example.solconnect.volley.VolleySingleton;
import com.honeywell.aidc.AidcManager;
import com.honeywell.aidc.BarcodeReader;
import com.honeywell.aidc.BarcodeReaderInfo;
import com.honeywell.aidc.InvalidScannerNameException;
import com.honeywell.aidc.ScannerUnavailableException;

import org.json.JSONException;
import org.json.JSONObject;

public class LoginActivity extends AppCompatActivity {

    private EditText etUsername, etPassword;
    private Button btnLogin;


    private AidcManager manager;
    private static BarcodeReader barcodeReader;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        initComponents();
        initListeners();

    }

    private void initListeners() {
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!etUsername.getText().toString().isEmpty() && !etPassword.getText().toString().isEmpty()){
                    Toast.makeText(LoginActivity.this, createJson().toString(), Toast.LENGTH_SHORT).show();
                    createJson();
                    String URL = "https://api-generator.retool.com/UQlsv5/data";
                    JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.GET, URL, null, new Response.Listener<JSONObject>() {
                        @Override
                        public void onResponse(JSONObject response) {
                            Toast.makeText(LoginActivity.this, "hola:"+response.toString(), Toast.LENGTH_SHORT).show();
                        }
                    }, new Response.ErrorListener() {
                        @Override
                        public void onErrorResponse(VolleyError error) {
                            Toast.makeText(LoginActivity.this, "Error", Toast.LENGTH_SHORT).show();
                        }
                    });

                    VolleySingleton.getInstance(LoginActivity.this).addToRequestQueue(jsonObjectRequest);
                    Intent intent = new Intent(LoginActivity.this,MenuActivity.class);
                    startActivity(intent);
////                    TODO: Manca controllo Login
                }
            }
        });
    }

    private JSONObject createJson() {

        String nome;
        try {

            nome = barcodeReader.getInfo().getScannerSerialNumber().toString();
        } catch (ScannerUnavailableException e) {
//            è un catch obligatorio
            throw new RuntimeException(e);
        }
        JSONObject jsonObject = new JSONObject();
        try {
            jsonObject.put(getString(R.string.login_api_user),etUsername.getText().toString());
            jsonObject.put(getString(R.string.login_api_password),etPassword.getText().toString());
            jsonObject.put(getString(R.string.login_api_serial_number),nome);
//            TODO: fare il serial number
        } catch (JSONException e) {
            e.printStackTrace();
        }

        return jsonObject;
    }

    private void initComponents() {
        etUsername = findViewById(R.id.etUsername);
        etPassword = findViewById(R.id.etPassword);
        btnLogin = findViewById(R.id.btnLogin);

//        creazione del singleton Aidcmanager
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

    static BarcodeReader getBarcodeReader() {
        return barcodeReader;
    }
}