package com.xpgsolutions.aplicacionsinactivity.imccalculaator;

import static com.xpgsolutions.aplicacionsinactivity.imccalculaator.IMCCalculatorActivity.IMC_KEY;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.xpgsolutions.aplicacionsinactivity.R;

public class RisultIMCActivity extends AppCompatActivity {

    private TextView tvResult, tvIMC, tvDescription;
    private Button btnRiCalculate;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_risult_imcactivity);
        double result = getIntent().getDoubleExtra(IMC_KEY, -1.0);

        initComponent();
        initUI(result);
        initListeners();
    }

    private void initListeners() {
        btnRiCalculate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onBackPressed();
            }
        });
    }

    private void initUI(double result) {
        tvIMC.setText(String.valueOf(result));
        if (result >= 0.00 && result <= 18.50) {
            tvResult.setText(getString(R.string.title_bajo_peso));
            tvResult.setTextColor(ContextCompat.getColor(this, R.color.peso_bajo));
            tvDescription.setText(getString(R.string.description_bajo_peso));
        } else if (result >= 18.51 && result <= 24.99) {//Peso normal
            tvResult.setText(getString(R.string.title_peso_normal));
            tvResult.setTextColor(ContextCompat.getColor(this, R.color.peso_normal));
            tvDescription.setText(getString(R.string.description_peso_normal));
        } else if (result >= 25.00 && result <= 29.99) {//Sobrepeso
            tvResult.setText(getString(R.string.title_sobrepeso));
            tvResult.setTextColor(ContextCompat.getColor(this, R.color.peso_sovrepeso));
            tvDescription.setText(getString(R.string.description_sobrepeso));
        } else if (result >= 30.00 && result <= 99.00) {//Obesidad
            tvResult.setText(getString(R.string.title_obesidad));
            tvResult.setTextColor(ContextCompat.getColor(this, R.color.obesidad));
            tvDescription.setText(getString(R.string.description_sobrepeso));
        } else {//error
            tvResult.setText(R.string.error);
            tvResult.setTextColor(ContextCompat.getColor(this, R.color.obesidad));
            tvDescription.setText(R.string.error);
        }

    }

    private void initComponent() {
        tvIMC = findViewById(R.id.tvIMC);
        tvDescription = findViewById(R.id.tvDescription);
        tvResult = findViewById(R.id.tvResult);
        btnRiCalculate = findViewById(R.id.btnRiCalculate);
    }
}