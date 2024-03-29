package com.example.solapp.SQLite;

import android.content.Context;

import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;

import com.example.solapp.SQLite.Entity.LogEntity;
import com.example.solapp.SQLite.Interfaccia.DaoLogEntity;

@Database(entities = {LogEntity.class}, version = 1)
public abstract class MyRoomDatabase extends RoomDatabase {

    public abstract DaoLogEntity daoLogEntity();
    private static final String DATABASE_NAME = "my_database";
    //Volatile permette di far in modo che tutti i fili vedano il valore piu recente di volatile
    private static volatile MyRoomDatabase INSTANCE;

    public static MyRoomDatabase getDatabase(final Context context){
        if (INSTANCE == null){
//            synchronized fa in modo che acceda solo una unica instanza e non crei vari
            synchronized (MyRoomDatabase.class){
                if (INSTANCE == null){
                    INSTANCE = Room.databaseBuilder(context.getApplicationContext(),
                            MyRoomDatabase.class, DATABASE_NAME).build();
                }
            }
        }
        return INSTANCE;
    }

}
