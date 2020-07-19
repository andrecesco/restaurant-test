USE [master]
GO

IF DB_ID('gft-data') IS NOT NULL
  set noexec on               -- prevent creation when already exists

CREATE DATABASE [gft-data];
GO