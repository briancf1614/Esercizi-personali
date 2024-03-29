package com.example.solapp.SQLite.Entity;

import androidx.annotation.Nullable;
import androidx.room.Dao;
import androidx.room.Entity;
import androidx.room.Insert;
import androidx.room.PrimaryKey;

import java.sql.Time;
import java.sql.Timestamp;
import java.time.Instant;
import java.util.Date;

@Entity
public class LogEntity {
    @PrimaryKey(autoGenerate = true)
    private long id;
    private String timestamp;
    private String LogKey;
    private String LogData;
    @Nullable
    private String Error;
    private Boolean Iserror;

    public long getId() {
        return id;
    }
    public void setId(long id) {
        this.id = id;
    }
    public String getTimestamp() {
        return timestamp;
    }
    public void setTimestamp(String timestamp) {
        this.timestamp = timestamp;
    }
    public String getLogKey() {
        return LogKey;
    }
    public void setLogKey(String logKey) {
        LogKey = logKey;
    }
    public String getLogData() {
        return LogData;
    }
    public void setLogData(String logData) {
        LogData = logData;
    }
    @Nullable
    public String getError() {
        return Error;
    }
    public void setError(@Nullable String error) {
        Error = error;
    }
    public Boolean getIserror() {
        return Iserror;
    }
    public void setIserror(Boolean iserror) {
        Iserror = iserror;
    }

}

