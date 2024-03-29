package com.xpgsolutions.proyecto013_controlrecycleview;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private String [] nombres = {"anana", "banana","cereza " , "kiwi", "limon", "manzana","naranja" ,"sandia"};
    private int[] precios = {170,120,260,155,130,180,120,39};
    private int[] fotos = {R.drawable.anana, R.drawable.banana, R.drawable.cereza, R.drawable.kiwi, R.drawable.limon, R.drawable.manzana, R.drawable.naranja, R.drawable.sandia};
    private RecyclerView rv1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        rv1 = findViewById(R.id.recyclerView);
        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);
        rv1.setLayoutManager(linearLayoutManager);

        rv1.setAdapter(new Adaptadorfrutas());
    }

    private class Adaptadorfrutas extends RecyclerView.Adapter<Adaptadorfrutas.AdaptadorfrutasHolder> {
        @NonNull
        @Override
        public AdaptadorfrutasHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
            return new AdaptadorfrutasHolder(getLayoutInflater().inflate(R.layout.itemfruta,parent,false));
        }

        @Override
        public void onBindViewHolder(@NonNull AdaptadorfrutasHolder holder, int position) {
            holder.imprimir(position);
        }

        @Override
        public int getItemCount() {
            return nombres.length;
        }

        private class AdaptadorfrutasHolder extends RecyclerView.ViewHolder implements View.OnClickListener {
            TextView tv1,tv2;
            ImageView iv1;
            public AdaptadorfrutasHolder(@NonNull View itemView) {
                super(itemView);
                iv1 = itemView.findViewById(R.id.imageView);
                tv1 = itemView.findViewById(R.id.tvnombre);
                tv2 = itemView.findViewById(R.id.tvprecio);
                itemView.setOnClickListener(this);
            }

            public void imprimir(int position) {
                iv1.setImageResource(fotos[position]);
                tv1.setText(nombres[position]);
                tv2.setText(String.valueOf(precios[position]));
            }

            @Override
            public void onClick(View v) {
                Toast.makeText(MainActivity.this, nombres[getLayoutPosition()], Toast.LENGTH_SHORT).show();
            }
        }
    }
}