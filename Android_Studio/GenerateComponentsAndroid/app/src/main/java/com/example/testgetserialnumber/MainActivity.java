package com.example.testgetserialnumber;

import android.content.Context;
import android.os.Bundle;
import android.view.ContextThemeWrapper;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.testgetserialnumber.entity.Campo;
import com.google.android.material.button.MaterialButton;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private LinearLayout lLHead, lLContent, lLFooter;
    private Button btnScan;
    private List<Campo> campi;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initComponents();



    }

    private void initComponents() {
        lLHead = findViewById(R.id.lLHead);
        lLContent = findViewById(R.id.lLContent);
        lLFooter = findViewById(R.id.lLFooter);

        campi = Arrays.asList(new Campo[]{
                new Campo("1", "TextView", "soy un TextView", "soy un TextView hint"),
                new Campo("2", "EditText", "soy un EditText", "soy un EditText hint"),
                new Campo("3", "CheckBox", "soy un CheckBox", "soy un CheckBox hint"),
                new Campo("4", "Button", "soy un Button", "soy un Button hint")
        });

        btnScan = findViewById(R.id.btnScan);
        btnScan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                lLContent.removeAllViews();
                generateCampi();
            }
        });
    }

    private void generateCampi() {
        if (campi != null) {
            LayoutInflater inflater = LayoutInflater.from(this); // Asegúrate de tener el contexto disponible
            View view;
            for (Campo campo : campi) {
                switch (campo.tipo) {
                    case "TextView":
//                        lLContent.addView(generateTextView(campo));
                        break;
                    case "EditText":
                        inflater = LayoutInflater.from(this); // Asegúrate de tener el contexto disponible

                        view = inflater.inflate(R.layout.custom_edittext, lLContent, false);
                        TextView textView = view.findViewById(R.id.textView);
                        textView.setText(campo.text);

                        EditText editText = view.findViewById(R.id.editText);
                        editText.setHint(campo.hint);

                        lLContent.addView(view);
                        break;
                    case "CheckBox":
//                        lLContent.addView(generateCheckBox(campo));
                        break;
                    case "Button":
                        inflater = LayoutInflater.from(this); // Asegúrate de tener el contexto disponible
                        view = inflater.inflate(R.layout.custom_buttom, lLContent, false);
                        lLContent.addView(view);
                        break;
                }
            }
        }
    }
}