package com.example.solapp.SQLite.Interfaccia;

import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;

import com.example.solapp.SQLite.Entity.LogEntity;

import java.util.List;

@Dao
public interface DaoLogEntity {
    // Esta es la interfaz DAO
        @Insert
        void insertData(LogEntity logEntity);
        @Query("SELECT * FROM LogEntity")
        List<LogEntity> getAllLogs();



}
