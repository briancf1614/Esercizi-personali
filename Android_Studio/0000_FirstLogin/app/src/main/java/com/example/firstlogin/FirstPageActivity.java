package com.example.firstlogin;

import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class FirstPageActivity extends AppCompatActivity {

    private TextView tvTitolo;
    private EditText etCitta;
    private Button btnCerca;
    private CardView cvAPISucess, cvAPIFail;
    private TextView tvUtente, tvPassword, tvCoord, tvWeather, tvTemp, tvTempMin, tvTempMax, tvPressione, tvUmidita, tvPressioneMare, tvPressioneTerra, tvVento, tvNubolePercentuale, tvPaese, tvCittaSelezionata;


    private String Login;
    private String Password;
    private String Citta = "";
    private String url = "";
    private RequestQueue requestQueue;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.first_page);
        Login = getIntent().getStringExtra("Login");
        Password = getIntent().getStringExtra("Password");
        initComponents();
        initUI();
        initListeners();
    }


    private void initListeners() {

        btnCerca.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!etCitta.getText().toString().isEmpty()) {

                    Citta = etCitta.getText().toString();
                    url = "https://api.openweathermap.org/data/2.5/weather?q=" + Citta + "&lang=it&appid=4677f0780b223c5a5d878bd3350210b5";

                    JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.GET, url, null, new Response.Listener<JSONObject>() {
                        @Override
                        public void onResponse(JSONObject response) {
                            try {


                                tvUtente.setText("Utente: " + Login);
                                tvPassword.setText("Password: " + Password);

                                if (response.has("coord")) {
                                    JSONObject coord = response.getJSONObject("coord");
                                    tvCoord.setText("Coord:\n       lon: " + (coord.has("lon") ? (coord.getDouble("lon")):"Valore non disponibile") + "\n       lat: " + (coord.has("lat") ? coord.getDouble("lat") : "Valore non disponibile"));
                                }

                                if (response.has("weather")) {
                                    JSONArray arrayWeather = response.getJSONArray("weather");
                                    JSONObject weather = arrayWeather.getJSONObject(0);
                                    tvWeather.setText("Weather: " + (weather.has("description") ? (weather.getString("description")):"Valore non disponibile"));
                                }
//
                                if (response.has("main")) {
                                    JSONObject main = response.getJSONObject("main");
                                    tvTemp.setText("Temp: " + (main.has("temp") ? (int)(main.getInt("temp") - 273.15) + "°C" : "Valore non disponibile"));
                                    tvTempMin.setText("TempMin: " + (main.has("temp_min") ? (int)(main.getInt("temp_min") - 273.15) + "°C" : "Valore non disponibile"));
                                    tvTempMax.setText("TempMax: " + (main.has("temp_max") ? (int)(main.getInt("temp_max") - 273.15) + "°C" : "Valore non disponibile"));
                                    tvPressione.setText("Pressione: " + (main.has("pressure") ? main.getInt("pressure"):"Valore non disponibile"));
                                    tvUmidita.setText("Umidita: " + (main.has("humidity") ? main.getInt("humidity"):"Valore non disponibile"));
                                    tvPressioneMare.setText("PressioneMare: " + (main.has("sea_level") ? main.getInt("sea_level"):"Valore non disponibile"));
                                    tvPressioneTerra.setText("PressioneTerra: " + (main.has("grnd_level") ? main.getInt("grnd_level"):"Valore non disponibile"));
                                }

                                if (response.has("wind")) {
                                    JSONObject wind = response.getJSONObject("wind");
                                    tvVento.setText("Vento: " + (wind.has("speed") ? wind.getDouble("speed"):"Valore non disponibile"));
                                }
//
                                if (response.has("clouds")) {
                                    JSONObject clouds = response.getJSONObject("clouds");
                                    tvNubolePercentuale.setText("NubolePercentuale: " + (clouds.has("all") ? (clouds.getInt("all") + "%"):"Valore non disponibile"));
                                }

                                if (response.has("sys")) {
                                    JSONObject sys = response.getJSONObject("sys");
                                    tvPaese.setText("Paese: " + (sys.has("country") ? sys.getString("country"):"Valore non disponibile"));
                                }
//
                                tvCittaSelezionata.setText("CittaSelezionata: " + (response.has("name") ? response.getString("name"):"Valore non disponibile"));

                                if (cvAPIFail.getVisibility()==View.VISIBLE){cvAPIFail.setVisibility(View.GONE);}
                                cvAPISucess.setVisibility(View.VISIBLE);

                            } catch (JSONException e) {

                                throw new RuntimeException(e);
                            }
                        }
                    }, new Response.ErrorListener() {
                        @Override
                        public void onErrorResponse(VolleyError error) {
                            if (cvAPISucess.getVisibility() == View.VISIBLE){cvAPISucess.setVisibility(View.GONE);}
                            cvAPIFail.setVisibility(View.VISIBLE);
                        }
                    });

                    requestQueue.add(jsonObjectRequest);


                }

            }
        });

    }

    private void initUI() {
        tvTitolo.setText("Ciao " + Login);
    }


    private void initComponents() {
        requestQueue = Volley.newRequestQueue(this);


        etCitta = findViewById(R.id.etCitta);
        tvTitolo = findViewById(R.id.tvtitolo);
        btnCerca = findViewById(R.id.btnCerca);
        cvAPISucess = findViewById(R.id.cvAPISuccess);
        cvAPIFail = findViewById(R.id.cvAPIFail);


        tvUtente = findViewById(R.id.tvUtente);
        tvPassword = findViewById(R.id.tvPassword);
        tvCoord = findViewById(R.id.tvCoord);
        tvWeather = findViewById(R.id.tvWeather);
        tvTemp = findViewById(R.id.tvTemp);
        tvTempMin = findViewById(R.id.tvTempMin);
        tvTempMax = findViewById(R.id.tvTempMax);
        tvPressione = findViewById(R.id.tvPressione);
        tvUmidita = findViewById(R.id.tvUmidita);
        tvPressioneMare = findViewById(R.id.tvPressioneMare);
        tvPressioneTerra = findViewById(R.id.tvPressioneTerra);
        tvVento = findViewById(R.id.tvVento);
        tvNubolePercentuale = findViewById(R.id.tvNubolePercentuale);
        tvPaese = findViewById(R.id.tvPaese);
        tvCittaSelezionata = findViewById(R.id.tvCittaSelezionata);
    }
}