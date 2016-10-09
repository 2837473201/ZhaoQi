 <input id="datetimepicker" type="text">           
<script type="text/javascript">
 $('#datetimepicker').datetimepicker({
 	format:"yyyy-mm-dd",//"yyyy-mm-dd","yyyy-mm-dd hh:mm ss","yyyy-mm-dd hh:ii:ss"
 	weekStart:1,//0-6,
 	language:"zh-cn",
	//startDate:"2016-08-21",
	//endDate:"2016-08-23",
	daysOfWeekDisabled:"0,3",//or[0,3]or"0,3"
 	showMeridian:false,
 	todayBtn:true,
 	todayHighlight:true,
 	keyboardNavigation:true,
 	forceParse:false,
 	pickerPosition:"bottom-right",
 	minuteStep:5,
 	isInline:true,
 	startView:2,
 	minView:2,
 	maxView:4,
 	autoclose:true,
 	//initialDate:"2018-06-05"
 });
</script>