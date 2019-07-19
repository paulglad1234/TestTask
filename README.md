# TestTask
MyFirstWebApplication<br>
Update 1:<br>
Всё работает, кроме:<br>
	-принятия данных в формате json, только через параметры и context.Request.Query. Отдаёт, как положено.<br>
	-Autofac.<br>
values.json выглядит так:<br>
	{ "Value":[value1, value2, ... ], "Time":[time1, time2, ...] },<br>
	то есть каждый пост запрос добавляет новую запись в списки.<br><br>
Update 2:<br>
То же самое, только json теперь выглядит, как:<br>
{ "Value": value1, "Time":time1},<br>
{ "Value": value2, "Time":time2},<br>
...............................<br>
{ "Value": valueN, "Time":timeN},<br>
то есть каждый пост запрос добавляет новый объект в конец файла<br><br>
Update 3:<br>
Теперь принимает данные в формате json.<br><br>
Update 4:<br>
+Autofac<br>
<h3>Вид запросов:</h3>
<table border="0">
	<tr align="left">
		<td valign="top">
			POST:<br>
			{ <br>"value":100<br>}
		</td>
		<td valign="top">
			GET:<br>
			{ <br>"from":49246,<br>"till":59222<br>}
		</td>
	</tr>
</table>
