# SQLBroker_and_SignalR
 <br/>
資料庫建置與設定

STEP 1 <br/>
先創建一個 Test 資料庫

STEP 2 <br/>
執行下列SQL語句建立Table，並建立測試資料
```SQL
Create Table Employees
(
	Id int primary key identity,
	Name nvarchar(50),
	Email nvarchar(50),
	Department nvarchar(50)
)
Go

SET NOCOUNT ON
Declare @counter int = 1

While(@counter <= 100)
Begin

	Declare @Name nvarchar(50) = 'ABC ' + RTRIM(@counter)
	Declare @Email nvarchar(50) = 'abc' + RTRIM(@counter) + '@pragimtech.com'
	Declare @Dept nvarchar(10) = 'Dept ' + RTRIM(@counter)

	Insert into Employees values (@Name, @Email, @Dept)
	Set @counter = @counter +1

	If(@Counter%100000 = 0)
		Print RTRIM(@Counter) + ' rows inserted'
End
```

STEP 3 <br/>
執行下列SQL語句設定資料庫SQL Broker啟用
```SQL
alter database Test set enable_broker with rollback immediate
```
