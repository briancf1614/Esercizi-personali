package com.example.newgeneratorelement;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.InputStream;
import java.lang.reflect.Array;
import java.util.Iterator;
import java.util.List;
import java.util.Set;

public class MainActivity extends AppCompatActivity {

    int positionPasso=0;
    LinearLayout linearLayout;
    Button btnAvvia;
    private JSONObject jsonObject;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
//        setContentView(R.layout.activity_main);
        initComponents();
        initListeners();












    }

    private void initListeners() {
        btnAvvia.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                try {
                    JSONArray fasi = jsonObject.getJSONObject("checklistoperativa").getJSONArray("fasi");
                    int fasiLenght = fasi.length();  //3 fasi

//                    for (int i=0; i<fasiLenght;i++){


                        JSONObject fase = fasi.getJSONObject(0);
                        String id = fase.getString("id");
                        JSONArray passi = fase.getJSONArray("passi");
//                        for (int y = 0; y<passi.length();y++){

                            JSONObject passo = passi.getJSONObject(positionPasso);
                            JSONArray campi = passo.getJSONArray("campi");
                            JSONArray transizioni = passo.getJSONArray("transizioni");

                            for (int z=0; z<campi.length();z++){
                                JSONObject campo = campi.getJSONObject(z);

                                generateElement(campo.getString("tipo").toString(),campo.getString("msg").toString(),campo.getString("valore").toString());
                            }




                } catch (JSONException e) {
                    throw new RuntimeException(e);
                }
                positionPasso += 1;

            }
        });
    }

    private void generateElement(String element, String msg, String valore) {
        Toast.makeText(this, "tipo: "+element+"\nmsg: "+msg+"\nvalore: "+valore, Toast.LENGTH_SHORT).show();
        if (element.equals("textarea")){

            LinearLayout boxtext = new LinearLayout(this);
            boxtext.setOrientation(LinearLayout.VERTICAL);

            TextView textView = new TextView(this);
            textView.setText(msg.toString());
            boxtext.addView(textView);

            EditText editText = new EditText(this);
            editText.setHint("inserisci il dato");
            boxtext.addView(editText);


            linearLayout.addView(boxtext);
        }

        if (element.equals("check")){
            LinearLayout boxcheck = new LinearLayout(this);
            boxcheck.setOrientation(LinearLayout.HORIZONTAL);

            CheckBox checkBox = new CheckBox(this);
            checkBox.setText(msg.toString());
            checkBox.setChecked(Boolean.parseBoolean(valore));
            boxcheck.addView(checkBox);

            linearLayout.addView(boxcheck);

        }
    }

    private void initComponents() {
        linearLayout = new LinearLayout(this);
        linearLayout.setOrientation(LinearLayout.VERTICAL);


        btnAvvia = new Button(this);
        btnAvvia.setText("Avvia");

        linearLayout.addView(btnAvvia);


        setContentView(linearLayout);


        try {
            InputStream inputStream = getAssets().open("info.json");
            int size = inputStream.available();
            byte[] buffer = new byte[size];
            inputStream.read(buffer);
            inputStream.close();
            String json = new String(buffer, "UTF-8");

            jsonObject = new JSONObject(json);
        // Utiliza el objeto JSON aquí
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

}