use master
go

create database WeatherForecast
on (
	name = WeatherForecast_Dat,
	filename = 'D:\CSDL\WeatherForecast.mdf',
	size = 8mb,
	filegrowth = 10%
)
log on (
	name = WeatherForecast_Log,
	filename = 'D:\CSDL\WeatherForecast.ldf',
	size = 8mb,
	filegrowth = 10%
)
go

use WeatherForecast
go

create table Weather (
	Location char(60) primary key,
	Data ntext,
	TimeGetData datetime
)
go

create proc USP_InsertData
@cityName char(60), @data ntext, @timeGetData datetime
as
begin
	declare @temp int
	select @temp = count(*) from dbo.Weather where Location = @cityName
	
	if (@temp > 0)
	begin
		Delete from dbo.Weather where Location = @cityName
	end
	insert into dbo.Weather values (@cityName, @data, @timeGetData)
end