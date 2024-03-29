package com.example.solconnect;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MenuActivity extends AppCompatActivity {

    private TextView tvUser,tvMatricola,tvCodiceStabilimento,tvDescrizioneStabilimento,SelezionaTipoGas;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);
        initComponents();
    }












    private void initComponents() {
        tvUser = findViewById(R.id.tvUser);
        tvMatricola = findViewById(R.id.tvMatricola);
        tvCodiceStabilimento = findViewById(R.id.tvCodiceStabilimento);
        tvDescrizioneStabilimento = findViewById(R.id.tvDescrizioneStabilimento);
        SelezionaTipoGas = findViewById(R.id.SelezionaTipoGas);
    }
}