package com.xpgsolutions.aplicacionsinactivity.todoapp;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.xpgsolutions.aplicacionsinactivity.R;

import java.util.List;

import kotlin.Unit;

public class TaskAdapter extends RecyclerView.Adapter<TaskViewHolder> {
    private List<Task> tasks;
    private OnTaskSelectedListener onTaskSelectedListener;
    TaskAdapter(List<Task> tasks,OnTaskSelectedListener onTaskSelectedListener){
        this.tasks = tasks;
        this.onTaskSelectedListener = onTaskSelectedListener;
    }


    @NonNull
    @Override
    public TaskViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_todo_task,parent,false);
        return new TaskViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull TaskViewHolder holder, int position) {
        holder.render(tasks.get(position));
        holder.itemView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (onTaskSelectedListener != null) {
                    onTaskSelectedListener.onTaskSelected(holder.getAdapterPosition());
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return tasks.size();
    }

    public interface OnTaskSelectedListener {
        void onTaskSelected(int position);
    }

}
