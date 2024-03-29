package com.xpgsolutions.spinneradapterpersonabile;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.text.Layout;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {


    private String[] paises = {"Argentina","Bolivia","Brasil"};
    private int[] banderas = {R.drawable.argentina,R.drawable.bolivia,R.drawable.brasil};
    private Spinner spinner;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        spinner = findViewById(R.id.spinner);

        PaisesAdapter adapter = new PaisesAdapter();
        spinner.setAdapter(adapter);

    }

    public void stampar(View view){
        Toast.makeText(this, "escogistes: " + spinner.getSelectedItem().toString(), Toast.LENGTH_SHORT).show();
    }

    class PaisesAdapter extends BaseAdapter{

        @Override
        public int getCount() {
            return paises.length;
        }

        @Override
        public Object getItem(int position) {
            return paises[position];
        }

        @Override
        public long getItemId(int position) {
            return 0;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            LayoutInflater inflater = LayoutInflater.from(MainActivity.this);
            convertView = inflater.inflate(R.layout.itemspinner,null);
            TextView tv1 = convertView.findViewById(R.id.tvpais);
            ImageView iv1 = convertView.findViewById(R.id.imageView);
            tv1.setText(paises[position]);
            iv1.setImageResource(banderas[position]);
            return  convertView;
        }
    }
}