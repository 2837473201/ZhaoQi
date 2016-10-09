 <input id="datetimepicker" type="text">           
<script type="text/javascript">
 $('#datetimepicker').datetimepicker({
 	value:'',
		lang:'ch',
		format:'Y-m-d',//'Y-m-d H:i',
		formatTime:'H:i',
		formatDate:'Y-m-d',
		step:60,
		closeOnDateSelect:0,//0,//
		closeOnWithoutClick:true,
		timepicker:false,//true,//
		datepicker:true,
		minDate:false,
		maxDate:false,
		minTime:false,
		maxTime:false,
		allowTimes:[],
		opened:false,
		inline:false,//true,//
 });
</script>