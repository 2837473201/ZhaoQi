!function(){}();//!
jQuery.noConflict();
jQuery(document).ready(function(jQuery){
	"use strict";
	var tagidObj={
		"温度1-1":"text5491-4",
		"温度1-2":"text5491-4-2",
		"温度2-1":"text5491-9",
		"温度2-2":"text5491-9-1",
		"温度3-1":"text5491-6",
		"温度3-2":"text5491-6-2",
		"温度4-1":"text5491-5",
		"温度4-2": "text5491-5-1",
		"1#进干流量": "text5491",
		"1#进湿阀": "text5491-4-2-0",
		"1#产气": "text5491-4-2-0",
		"2#进干流量": "text5491-0",
		"2#进湿阀": "text5491-9-1-9",
		"2#产气": "text5491-4-2-0",
		"3#进干流量": "text5491-8",
		"3#进湿阀": "text5491-6-2-0",
		"3#产气": "text5491-4-2-0",
		"4#进干流量": "text5491-01",
		"4#进湿阀":"text5491-5-1-4",
		"4#产气": "text5491-4-2-0",
		"罐体压力":"text5491-5-3",
		"供气流量":"text5491-5-8",
		"供气压力":"text5491-5-7",
		"储气压力":"text5491-5-71",
	};
	var tagvalueObj={
	    "温度1-1": "400101",
	    "温度1-2": "400102",
	    "温度2-1": "400103",
	    "温度2-2": "400104",
	    "温度3-1": "400105",
	    "温度3-2": "400106",
	    "温度4-1": "400107",
	    "温度4-2": "400108",
	    "1#进干流量":"400201",
	    "1#进湿阀":"400202",
	    "1#产气": "400203",
	    "2#进干流量": "400204",
	    "2#进湿阀": "400205",
	    "2#产气": "400206",
	    "3#进干流量": "400207",
	    "3#进湿阀": "400208",
	    "3#产气": "400209",
	    "4#进干流量": "400210",
	    "4#进湿阀": "400211",
	    "4#产气": "400212",
	    "罐体压力": "400213",
	    "供气流量": "400215",
	    "供气压力": "400216",
	    "储气压力": "400214",
	};
	init();
	function init(){
		showRealtimeValue();
	}
	function showRealtimeValue(){
		//for(var i in tagidObj){
		//	Snap("#"+tagidObj[i]).node.textContent=tagvalueObj[i];
	    //}.
	    ReadData();
	}
    
    function ReadData() {
        jQuery.get('../api/RealData', function (data) {
            var dataModel = JSON.parse(data);
            for (var i in tagidObj) {
                Snap("#" + tagidObj[i]).node.textContent = dataModel[tagvalueObj[i]].TagValue + dataModel[tagvalueObj[i]].TagUint;
            }
            setTimeout(ReadData, 1000);
        });
    }




});

