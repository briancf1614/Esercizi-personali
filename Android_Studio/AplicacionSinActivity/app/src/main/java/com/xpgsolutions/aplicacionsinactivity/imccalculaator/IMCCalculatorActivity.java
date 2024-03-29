package com.xpgsolutions.aplicacionsinactivity.imccalculaator;

import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;
import androidx.core.content.ContextCompat;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.slider.RangeSlider;
import com.xpgsolutions.aplicacionsinactivity.R;

import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.Format;
import java.util.Locale;

public class IMCCalculatorActivity extends AppCompatActivity {

    private Boolean isMaleSelected = true;
    private Boolean isFemaleSelected = false;
    private CardView cvMale, cvFemale;
    private TextView tvHeight;
    private RangeSlider rsHeight;
    private FloatingActionButton btnSubtractWeight;
    private FloatingActionButton btnPlusWeight;
    private TextView tvweight;
    private int currentWeight = 70;
    private int currentAge = 18;
    private FloatingActionButton btnSubtractAge;
    private FloatingActionButton btnPlusAge;
    private TextView tvAge;
    private Button btnCalculate;
    private int currentHeight = 120;
    public static final String IMC_KEY = "IMC_RESULT";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_imccalculator);
        initComponents();
        initListeners();
        initUI();
    }


    private void initComponents() {
        cvMale = findViewById(R.id.viewMale);
        cvFemale = findViewById(R.id.viewFemale);
        tvHeight = findViewById(R.id.tvheight);
        rsHeight = findViewById(R.id.rsheight);
        btnSubtractWeight = findViewById(R.id.btnSubtractWeight);
        btnPlusWeight = findViewById(R.id.btnPlusWeight);
        tvweight = findViewById(R.id.tvweight);
        tvAge = findViewById(R.id.tvAge);
        btnPlusAge = findViewById(R.id.btnPlusAge);
        btnSubtractAge = findViewById(R.id.btnSubtractAge);
        btnCalculate = findViewById(R.id.buttonCalculate);
    }

    private void initListeners() {
        cvMale.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                changeGender();
                setGenderColor();
            }
        });
        cvFemale.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                changeGender();
                setGenderColor();
            }
        });
        rsHeight.addOnChangeListener((slider, value, fromUser) -> {
            DecimalFormat df = new DecimalFormat("#.##");
            currentHeight = Integer.parseInt(df.format(value));
            tvHeight.setText(String.valueOf(currentHeight) + " cm");
        });

        btnPlusWeight.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                currentWeight += 1;
                setWeigth();
            }
        });
        btnSubtractWeight.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                currentWeight -= 1;
                setWeigth();
            }
        });
        btnPlusAge.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                currentAge += 1;
                setAdge();
            }
        });
        btnSubtractAge.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                currentAge -= 1;
                setAdge();
            }
        });
        btnCalculate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                double result = calculateIMC();
                navigateToResult(result);
            }
        });
    }

    private void navigateToResult(double result) {
        Intent intent = new Intent(this, RisultIMCActivity.class);
        intent.putExtra(IMC_KEY, result);
        startActivity(intent);
    }

    private double calculateIMC() {

        // Configurar DecimalFormatSymbols para usar punto como separador decimal
        DecimalFormatSymbols symbols = new DecimalFormatSymbols(Locale.US);
        symbols.setDecimalSeparator('.');


        DecimalFormat df = new DecimalFormat("#.##",symbols);
        double imc = (double) currentWeight / ((double) currentHeight / 100 * (double) currentHeight / 100);
        String resultString = df.format(imc);
        double result = Double.parseDouble(df.format(imc));
        String hola1 = "el resultado es: "+ result;
        String hola2 = "Sabes cual es el resultado?";
        return result;
    }

    private void setAdge() {
        tvAge.setText(String.valueOf(currentAge));
    }

    private void setWeigth() {
        tvweight.setText(String.valueOf(currentWeight));
    }

    private void changeGender() {
        isMaleSelected = !isMaleSelected;
        isFemaleSelected = !isFemaleSelected;
    }

    private void setGenderColor() {
        cvMale.setCardBackgroundColor(getBackgroundColor(isMaleSelected));
        cvFemale.setCardBackgroundColor(getBackgroundColor(isFemaleSelected));
    }

    private int getBackgroundColor(Boolean isActivated) {
        int colorReference;
        if (isActivated) {
            colorReference = R.color.background_component_selected;
        } else {
            colorReference = R.color.background_component;
        }

        return ContextCompat.getColor(this, colorReference);
    }

    private void initUI() {
        setGenderColor();
        setWeigth();
        setAdge();
    }


}