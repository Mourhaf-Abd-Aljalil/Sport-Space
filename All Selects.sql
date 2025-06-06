
--1-جبلي عدد اللاعبين يلي لعبوا بالحجز رقم واحد مثلا 

select COUNT(*) as NumberOfPlayers From (
select C.Name , C.Customer_Type  from Booking Bo
INNER JOIN Booker Br
on Br.Booker_ID = Bo.Booker_ID
INNER JOIN Customer C 
ON C.Booker_ID = Br.Booker_ID
where C.Customer_Type is NOT NULL AND Bo.Booker_ID = 1
GROUP by C.Name , C.Customer_Type
)R1

--2-جبلي عدد اللاعبين يلي لم لعبوا بالحجز رقم واحد مثلا 

select COUNT(*) as NumberOfNonPlayers From (
select C.Name , C.Customer_Type  from Booking Bo
INNER JOIN Booker Br
on Br.Booker_ID = Bo.Booker_ID
INNER JOIN Customer C 
ON C.Booker_ID = Br.Booker_ID
where C.Customer_Type is  NULL AND Bo.Booker_ID = 3
GROUP by C.Name , C.Customer_Type
)R1 

--3جبلي عدد اللاعبين يلي لعبو بكل حجز 

select  C.Booker_ID,COUNT(C.Booker_ID) as playerPlayed from Customer C
where C.Customer_Type is not null 
GRoup by C.Booker_ID

--4  Number of not player

select  C.Booker_ID,COUNT(C.Booker_ID)as  playerNotPlayed from Customer C
where C.Customer_Type is  null 
GRoup by C.Booker_ID
 
--5-جبلي حجوزات الملعب رقم 8 مع أوقاتهم و تكلفتهم( يعني بدنا تاريخ اللعبة لكل حجز و تكلفتها و لاي ملعب تابعة )

select B.Field_ID, B.Booking_Date , B.Start_Time  , B.End_Time , B.Booking_Cost From Booking B
where B.Field_ID = 8;

--6 جبلي اسم المالك لهاد الملعب المحجوز

select O.Name, B.Field_ID, B.Booking_Date , B.Start_Time  , B.End_Time , B.Booking_Cost From Booking B
INNER JOIN Field F 
ON F.Field_ID = B.Booker_ID 
INNER JOIN Owner O 
ON O.Owner_ID = F.Owner_ID
where B.Field_ID = 8;

--7-جبلي booker يلي دفعة بالطريقة (اختاروا طريقة من طرق الدفع الموجودة بجدول ال payment)

select Br.Name , Br.Email From Booker Br
INNER JOIN Booking Bo
ON Bo.Booker_ID = Br.Booker_ID
INNER JOIN Payment Pa
ON Pa.Booking_ID = Bo.Booking_ID
where Pa.Payment_Method = 'Credit Card';

--8-جبلي كل الملاعب و الخدمات يلي بقدموها 

select f.Field_ID,s.Service_Name from Field f 
INner join Field_Services fs on f.Field_ID = fs.Field_ID 
inner join Services s on s.Service_ID = fs.Service_ID

--9-جبلي كل الملاعب و كم خدمة بقدم  

select f.Field_ID,COUNT(fs.Service_ID)as NumberOfServices from Field f 
INner join Field_Services fs on f.Field_ID = fs.Field_ID 
inner join Services s on s.Service_ID = fs.Service_ID 
group by f.Field_ID

--10-جبلي كل الملاعب و الخدمات يلي بقدموها يلي سعرها اقل من 30 

select f.Field_ID,s.Service_Name , s.Service_Cost from Field f 
INner join Field_Services fs on f.Field_ID = fs.Field_ID 
inner join Services s on s.Service_ID = fs.Service_ID
where s.Service_Cost < 30

--11-جبلي كل ملعب و مالكه و شقد تكلفة حجزه 

select f.Field_Name , B.Booking_Cost From Field f
INNER JOIN Booking B
ON B.Field_ID = f.Field_ID

--12 جبلي اسم المالك لهاد الملعب المحجوز

select  B.Field_ID,F.Field_Name, B.Booking_Date , B.Start_Time  , B.End_Time , B.Booking_Cost From Booking B
INNER JOIN Field F 
ON F.Field_ID = B.Booker_ID 
INNER JOIN Owner O 
ON O.Owner_ID = F.Owner_ID

--13-جبلي اسم booker و عدد الأشخاص يلي تابعين لهاد الحجز سواء رح يلعبوا أو لا 

select C.Booker_ID , B.Name ,Count(C.Booker_ID) as AllPlayersOfBooker  from Customer C
INNER JOIN Booker B 
ON B.Booker_ID = C.Booker_ID
Group by C.Booker_ID , B.Name

--14-جبلي كل ملعب و العروض الموجودة فيه و جبلي ال  اذا كان الملعب ما فيه عروض 

select f.Field_Name , O.Descripyion From Field f 
 Join Offers o
ON O.Field_ID = f.Field_ID
Order by f.Field_Name

--15-جبلي كل ملعب و العروض الموجودة فيه  

select f.Field_Name , O.Descripyion , O.DiscountPercenttag From Field f 
right Join Offers o
ON O.Field_ID = f.Field_ID 
--where o.DiscountPercenttag >20
order by f.Field_Name

--16 Number of Offers for each field 

select f.Field_Name , COUNT(f.Field_Name) as NumberOfOffersForEachField From Field f 
 Join Offers o
ON O.Field_ID = f.Field_ID
Group by f.Field_Name
Order by f.Field_Name

--17 Field that has more than 3 offers

select f.Field_Name , COUNT(f.Field_Name)as NumberOfOffersGreaterThanOrEqual3 From Field f 
 Join Offers o
ON O.Field_ID = f.Field_ID
Group by f.Field_Name
having COUNT(f.Field_Name) >=3
Order by f.Field_Name

--18

select f.Field_Name , f.Location,NumberOfBooking = COUNT(Bo.Booker_ID) from Booker Br
INNER JOIN Booking Bo
ON Bo.Booker_ID = Br.Booker_ID
INNER JOIN Field f
ON f.Field_ID = Bo.Field_ID
Group by f.Field_Name , f.Location 

--19

select f.Field_Name , f.Location ,Bo.Start_Time , Bo.End_Time  from Booker Br
INNER JOIN Booking Bo
ON Bo.Booker_ID = Br.Booker_ID
INNER JOIN Field f
ON f.Field_ID = Bo.Field_ID

--20

select Br.Booker_ID , Br.Name , Br.Phone_Number ,NumberOfBooking = COUNT(Bo.Booker_ID) from Booker Br
INNER JOIN Booking Bo
ON Bo.Booker_ID = Br.Booker_ID
INNER JOIN Field f
ON f.Field_ID = Bo.Field_ID
Group by Br.Booker_ID , Br.Name , Br.Phone_Number 

--21

select Br.Booker_ID , Br.Name , Br.Phone_Number ,NumberOfBooking = COUNT(Bo.Booker_ID) from Booker Br
INNER JOIN Booking Bo
ON Bo.Booker_ID = Br.Booker_ID
INNER JOIN Field f
ON f.Field_ID = Bo.Field_ID
Group by Br.Booker_ID , Br.Name , Br.Phone_Number 
having COUNT(Bo.Booker_ID) > 3

--22-جبلي آخر حجز و لاي ملعب تابع (آخر حجز هو أكبر تاريخ )

select top 1 f.Field_Name , f.Location ,Bo.Start_Time , Bo.End_Time  from Booker Br
INNER JOIN Booking Bo
ON Bo.Booker_ID = Br.Booker_ID
INNER JOIN Field f
ON f.Field_ID = Bo.Field_ID
order by Bo.End_Time desc

--23-جبلي التقييمات و كل تقيم تابع لاي زبون 

select C.Name, R.Rating , R.Comment from Customer C
INNER JOIN Review R
ON R.Customer_ID = C.Customer_ID

--24-جبلي التقييمات و كل تقييم تابع لاي ملعب 

select F.Field_Name, R.Rating from Customer C
INNER JOIN Review R
ON R.Customer_ID = C.Customer_ID
INNER JOIN Booker B
ON B.Booker_ID = C.Booker_ID
INNER JOIN Booking Bo
ON Bo.Booker_ID = B.Booker_ID
INNER JOIN Field F
ON F.Field_ID = Bo.Field_ID
Order by F.Field_Name

--25

select distinct F.Field_Name, R.Rating from Customer C
INNER JOIN Review R
ON R.Customer_ID = C.Customer_ID
INNER JOIN Booker B
ON B.Booker_ID = C.Booker_ID
INNER JOIN Booking Bo
ON Bo.Booker_ID = B.Booker_ID
INNER JOIN Field F
ON F.Field_ID = Bo.Field_ID
where R.Rating = 5
Order by F.Field_Name

--26-جبلي كل الملاعب يلي تقييمات فيها 5 

select F.Field_Name, COUNT(R.Rating) from Customer C
INNER JOIN Review R
ON R.Customer_ID = C.Customer_ID
INNER JOIN Booker B
ON B.Booker_ID = C.Booker_ID
INNER JOIN Booking Bo
ON Bo.Booker_ID = B.Booker_ID
INNER JOIN Field F
ON F.Field_ID = Bo.Field_ID
where R.Rating = 5
Group by F.Field_Name
Order by F.Field_Name

--27-جبلي كل الزبونات يلي قيموا ب 5 و لاي ملعب هنن قيموا و حصرا يكونوا لعبوا (customer-type =0||1)
select distinct B.Name,F.Field_Name  from Customer C
INNER JOIN Review R
ON R.Customer_ID = C.Customer_ID
INNER JOIN Booker B
ON B.Booker_ID = C.Booker_ID
INNER JOIN Booking Bo
ON Bo.Booker_ID = B.Booker_ID
INNER JOIN Field F
ON F.Field_ID = Bo.Field_ID
where R.Rating = 5 AND C.Customer_Type in(0 , 1);

--28- جبلي اسماء الزبونات يلي قيموا و ما لعبوا من الأساس وشقد قيمو  

select C.Name , R.Rating   from Customer C
INNER JOIN Review R
ON R.Customer_ID = C.Customer_ID
INNER JOIN Booker B
ON B.Booker_ID = C.Booker_ID
where  C.Customer_Type is NULL;

--28-جبلي الملاعب يلي بتقدم الخدمة الفلانية(منحتار اي خدمة من جدول الخدمات)

select f.Field_Name , f.Location from Field f
INNER JOIN Field_Services fs
ON fs.Field_ID = f.Field_ID
INNER JOIN Services S
ON S.Service_ID = fs.Service_ID
where S.Service_Name = 'Court Rental'

--29

select f.Field_Name , f.Location,S.Service_Name,S.Service_Cost from Field f
INNER JOIN Field_Services fs
ON fs.Field_ID = f.Field_ID
INNER JOIN Services S
ON S.Service_ID = fs.Service_ID
where S.Service_Cost >50

--30

select f.Field_Name , f.Location,S.Service_Name,S.Service_Cost from Field f
INNER JOIN Field_Services fs
ON fs.Field_ID = f.Field_ID
INNER JOIN Services S
ON S.Service_ID = fs.Service_ID
where S.Service_Cost <50

--31

select f.Field_ID,f.Field_Name , f.Location ,COUNT(fs.Field_ID) as NumberOfService
from Field f
INNER JOIN Field_Services fs
ON fs.Field_ID = f.Field_ID
INNER JOIN Services S
ON S.Service_ID = fs.Service_ID
group by f.Field_ID, f.Field_Name , f.Location

--32

select f.Field_ID,f.Field_Name , f.Location ,COUNT(fs.Field_ID) as NumberOfService
from Field f
INNER JOIN Field_Services fs
ON fs.Field_ID = f.Field_ID
INNER JOIN Services S
ON S.Service_ID = fs.Service_ID
group by f.Field_ID, f.Field_Name , f.Location
having COUNT(fs.Field_ID) > 3

--33-جبلي كل الملاعب يلي سعر حجزهم اكتر من 100 (ملاحظة نحن حطينا اسعار الحجز ارقام بين ال 0 و 200 و ما حددنا نوع العملة )

select F.Field_Name,F.Location, B.Booking_Cost from Field F
INNER JOIN Booking B
ON B.Field_ID = F.Field_ID
where B.Booking_Cost > 100

--34-جبلي الخدمات كل الملاعب و خدماتهم بحيث سعر الخدمة اكبر تماما من50 

select f.Field_Name , f.Location,S.Service_Name,S.Service_Cost from Field f
INNER JOIN Field_Services fs
ON fs.Field_ID = f.Field_ID
INNER JOIN Services S
ON S.Service_ID = fs.Service_ID
where S.Service_Cost >50


--35-جبلي كل الملاعب يلي عندها عروض بحيث الخصم اكبر تماما من 20 

select f.Field_Name , O.Descripyion , O.DiscountPercenttag From Field f 
right Join Offers o
ON O.Field_ID = f.Field_ID 
where o.DiscountPercenttag >20
order by f.Field_Name


--36-جبلي كل الbooker يلي دفعوا بالتاريخ (انتو اختاروا تاريخ عكيفكم )
select b.Name,bk.Booking_Date from 
booker b inner join booking bk 
on b.Booker_ID = bk.Booker_ID
--where bk.Booking_Date = '2025-04-21'
WHERE YEAR(bk.Booking_Date ) = 2025 --by year 

--37-جبلي ال customer يلي عندهم لعبة بالتاريخ الفلاني (كمان انتو اختاروا تاريخ)
select b.Booker_ID, c.Name from 
Customer c inner join Booker b 
on c.Booker_ID = b.Booker_ID 
inner join Booking bk on bk.Booker_ID = b.Booker_ID
where bk.Booking_Date ='2025-05-05'

--38-جبلي كل ال booer يلي حاجزين بالتاريخ الفلاني و اي ملعب هنن حاجزين 
SELECT B.Booker_ID, B.Name, B.Email, B.Phone_Number, F.Field_Name, F.Location 
FROM Booking BK
JOIN Booker B ON BK.Booker_ID = B.Booker_ID
JOIN Field F ON BK.Field_ID = F.Field_ID
WHERE BK.Booking_Date = '2025-05-07';

--39-جبلي الملاعب يلي بتقدم خدمتين أو أكثر هي select تانية تكملة للاولي التنتين بفيدونا(مع تفاصيل الخدمتين )

SELECT
    f.Field_ID,
    f.Field_Name,
    s.Service_Name,
    s.Service_Cost
FROM Field f
INNER JOIN Field_Services fs ON f.Field_ID = fs.Field_ID
INNER JOIN Services s ON s.Service_ID = fs.Service_ID
WHERE f.Field_ID IN (
    SELECT fs.Field_ID 
    FROM Field_Services fs
    INNER JOIN Services s ON s.Service_ID = fs.Service_ID
    GROUP BY fs.Field_ID
    HAVING COUNT(fs.Service_ID) >= 2
);


--40-جبلي الملاعب يلي بتقدم اكتر من عرضين هي select تانية تكملة للاولي التنتين بفيدونا(مع تفاصيل هدول العرضين) 

select f.Field_ID,f.Field_Name,fo.Descripyion,fo.DiscountPercenttag from Offers fo
inner join Field f on f.Field_ID = fo.Field_ID
where fo.Field_ID IN(
select f.Field_ID    from
Field f inner join Offers fo on
f.Field_ID = fo.Field_ID 
group by f.Field_ID
having COUNT(fo.Offer_ID) > 2
) 
order by Field_ID

--41-جبلي الملاعب يلي عليها اكتر من حجز من التاريخ كذا إلى التاريخ كذا 

select f.Field_ID , f.Field_Name,COUNT(bk.Booking_Date) as NumberOfBooking from Field f 
inner join booking bk on
f.Field_ID = bk.Field_ID 
where bk.Booking_Date between '2020-05-02' AND '2025-05-28'
group by f.Field_ID, f.Field_Name
having COUNT(bk.Booking_Date) > 1

--42-جبلي ال booker يلي لسا ما دفعوا 
--here the booker who doesn't have the booking session so he doesn't pay 

--select b.Name from Booker b where 
--b.Booker_ID not in (
--	select b.Booker_ID from  Booker b 
--	right join Booking bk on bk.Booker_ID = b.Booker_ID 
--)
--
----28 يلي ما دفعوا  booker ال
--
--SELECT b.Booker_ID, b.Name, b.Email, b.Phone_Number
--FROM Booker b
--JOIN Booking bk ON b.Booker_ID = bk.Booker_ID
--LEFT JOIN Payment p ON bk.Booking_ID = p.Booking_ID
--WHERE p.Payment_ID IS NULL;
--

--43-جبلي الملاعب يلي تقييمها ضعيف يعني 1 و شو السبب يعني ال comment

select distinct f.Field_Name,f.Location,re.Comment from Review re 
inner join Customer co on 
co.Customer_ID = re.Customer_ID 
inner join Booker bo on 
bo.Booker_ID = co.Booker_ID 
inner join Booking bk on
bk.Booker_ID = bo.Booker_ID 
inner join Field f on 
f.Field_ID = bk.Field_ID 
where re.Rating = 1

  ---  واسم الملعب وموقع الملعب customer التابع له وعدد ال booker واظهار معلومات الbooking_id=15 اظهار تاريخ بدء وانتهاء الحجز رقم---

select b.Booker_ID,b.Name,b.Email,b.Phone_Number,count(c.Customer_ID)as countcustomer,bg.Start_Time,bg.End_Time,f.Field_Name,f.Location
from Customer c inner join Booker b on b.Booker_ID=c.Booker_ID inner join Booking bg on bg.Booker_ID=b.Booker_ID
inner join Field f on bg.Field_ID=f.Field_ID
where bg.Booking_ID=10
group by b.Booker_ID,b.Name,b.Email,b.Phone_Number,bg.Start_Time,bg.End_Time,f.Field_Name,f.Location

 ---وعدد حجوزاته ومجموع قيمة حجوزاته booker_name اظهار ---

select b.Name,count (bg.Booking_ID)as countbooking_id,sum(bg.Booking_Cost)as sumBooking_Cost
from booking bg inner join Booker b on bg.Booker_ID=b.Booker_ID 
group by b.Name


--ايرادات كل ملعب 
SELECT f.Field_Name, SUM(b.Booking_Cost) AS Total_Revenue
FROM Field f
JOIN Booking b ON f.Field_ID = b.Field_ID
GROUP BY f.Field_Name
ORDER BY Total_Revenue DESC;



--طرق الدفع الأكثر استخدام منشان يفيدنا نحط الحالة  
SELECT p.Payment_Method, COUNT(p.Payment_ID) AS Payment_Count
FROM Payment p
GROUP BY p.Payment_Method
ORDER BY Payment_Count DESC;