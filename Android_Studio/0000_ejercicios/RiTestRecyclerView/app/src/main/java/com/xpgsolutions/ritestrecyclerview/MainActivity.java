package com.xpgsolutions.ritestrecyclerview;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private String [] nombres = {"anana", "banana","cereza " , "kiwi", "limon", "manzana","naranja" ,"sandia"};
    private int[] precios = {170,120,260,155,130,180,120,39};
    private int[] fotos = {R.drawable.anana, R.drawable.banana, R.drawable.cereza, R.drawable.kiwi, R.drawable.limon, R.drawable.manzana, R.drawable.naranja, R.drawable.sandia};
    private RecyclerView rv1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        rv1 = findViewById(R.id.rv1);
        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);
        rv1.setLayoutManager(linearLayoutManager);
        rv1.setAdapter(new AdaptadorFrutas());


    }

    private class AdaptadorFrutas extends RecyclerView.Adapter<AdaptadorFrutas.Adaptadorfrutasholder> {
        @NonNull
        @Override
        public Adaptadorfrutasholder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
            return new Adaptadorfrutasholder(getLayoutInflater().inflate(R.layout.recycleview,parent,false));
        }

        @Override
        public void onBindViewHolder(@NonNull Adaptadorfrutasholder holder, int position) {
            holder.imprimir(position);
        }

        @Override
        public int getItemCount() {
            return nombres.length;
        }

        private class Adaptadorfrutasholder extends RecyclerView.ViewHolder{

            TextView tv1,tv2;
            ImageView iv1;
            public Adaptadorfrutasholder(@NonNull View itemView) {
                super(itemView);
                iv1 = itemView.findViewById(R.id.ivfruta);
                tv1 = itemView.findViewById(R.id.tvnombre);
                tv2 = itemView.findViewById(R.id.tvprecio);
            }

            public void imprimir(int position) {
                iv1.setImageResource(fotos[position]);
                tv1.setText(nombres[position]);
                tv2.setText(String.valueOf(precios[position]));
            }
        }
    }
}