!function () { }();//!
//jQuery.noConflict();
jQuery(document).ready(function ($) {
    var dtData;
    var dtData2;
    mainDt();
    var dt;
    //var arr3 = arrobjDeepcopy(arr111);
    function deepCopyFn(source) {
        var result = {};
        for (var key in source) {
            result[key] = typeof source[key] === 'object' ? deepCoyp(source[key]) : source[key];
        }
        return result;
    }
    function arrobjDeepcopy(arr) {//深度复制数组中的每个对象
        var arr2 = [];
        for (var i = 0; i < arr.length; i++) {
            arr2[i] = deepCopyFn(arr[i]);
        }
        return arr2;
    }
    function mainDt() {
        var currentTime = moment(new Date().getTime()).format("YYYY-MM-DD");
        $("#startTime").val(currentTime);
        $("#endTime").val(currentTime);
        $('#startTime').datetimepicker();
        $('#endTime').datetimepicker();
        $(function () { $("[data-toggle='tooltip']").tooltip(); });
        getwindowinnerWidth();
        function getwindowinnerWidth() {
            var wiw = window.innerWidth;
            var wih = window.innerHeight;
            if (wiw < 768) {
                $(".dt-buttons").css("display", "none");
            }
        }
        $.each(["#startTime", "#endTime"], function (index,value) {
            $(value).datetimepicker({
                lang: 'ch',
                format: 'Y-m-d',//'Y-m-d H:i',
                formatTime: 'H:i',
                formatDate: 'Y-m-d',
                step: 60,
                timepicker: false,//true,//
                datepicker: true,
            });
        });//each
        $.get("../api/DataTablesdf", { "strStart": "2016-09-06", "strEnd": "2016-09-07", "strVillage": "裴塘" }, function (d) {
            d.Table = addColID(d.Table);
            dtData = d;
            console.log(dtData);
            dtData2 = arrobjDeepcopy(dtData.Table);
            initDataTables();
            initLineHighC(dtData);
        });//get
    }
  
    $("#dtQueryBtn").click(function () {
        $.get("../api/DataTablesdf", { "strStart": $("#startTime").val(), "strEnd": $("#endTime").val(), "strVillage": $("#villageSelect").find("option:selected").text() }, function (d) {
            d.Table = addColID(d.Table);
                dtData = d;
                console.log(dtData);
                dtData2 = arrobjDeepcopy(dtData.Table);
                initDataTables(0);
                initLineHighC(dtData);
            });//get
       
    });
    function addColID(arr) {
        for (var i = 0; i < arr.length; i++) {
            arr[i]["ID"] = parseInt(i + 1);
        }
        return arr;
    }
    function initDataTables(a) {
        if (a == 0) {
            console.log(dt);
            dt.fnDestroy();
            $('#example').empty();
        }
        // dtData = $.parseJSON(dtData);
        var columnsArr = pickColumnsArr(dtData2);
        function pickColumnsArr(json) {
            var arr = [];
            var j = 0;
            for (var i in json[0]) {
                arr[j] = {
                    data: "",
                    title: "",
                };
                arr[j]["data"] = i;
                arr[j]["title"] = i;
                j++;
            }
            arr.splice(0, 0, arr[arr.length - 1]);
            arr.pop();
            return arr;
        }

       dt=$('#example').dataTable({
            //"ajax": "data/objects.txt",
            "data": dtData2,
            "order": false,
            "columns": columnsArr,
            "language": {

                "sProcessing": "处理中...",
                "sZeroRecords": "没有匹配结果",
                "sInfoPostFix": "",

                "sSearch": "搜索:",

                "sUrl": "",

                "sEmptyTable": "表中数据为空",

                "sLoadingRecords": "载入中...",

                "sInfoThousands": ",",
                "lengthMenu": "每页 _MENU_ 条记录",
                "zeroRecords": "没有找到记录",
                "info": "第 _PAGE_ 页 ( 总共 _PAGES_ 页 )",
                "infoEmpty": "无记录",
                "infoFiltered": "(从 _MAX_ 条记录过滤)",

                "oPaginate": {

                    "sFirst": "首页",

                    "sPrevious": "上页",

                    "sNext": "下页",

                    "sLast": "末页"

                },

                "oAria": {

                    "sSortAscending": ":以升序排列此列",

                    "sSortDescending": ":以降序排列此列"

                }

            },
            //"bStateSave": true,
            //"sScrollX": "100%",
            "scrollY": true,
            "scrollX": true,
            //"bScrollCollapse": true,
            "iDisplayLength": 10,
            "aLengthMenu": [10, 25, 50, -1],
            // "pageLength":31,
            "bLengthChange": true,
            "pagingType": "full_numbers",
            dom: '<"toolbar">Bfrtip',
            //dom: 'B<"toolbar">frtip',
            buttons: [{
                extend: 'excelHtml5',
                text: '<span class="glyphicon glyphicon-export" style="color:#3AF"></span>&nbsp;<span style="color:blue;">Excel</span>',
                customize: function (xlsx) {
                    var sheet = xlsx.xl.worksheets['sheet1.xml'];
                }
            }, {
                extend: 'csv',
                text: '<span class="glyphicon glyphicon-export" style="color:#3AF"></span>&nbsp;<span style="color:blue;">CSV</span>',
                exportOptions: {
                    modifier: {
                        search: 'none'
                    }
                }
            }]
       }); //dataTables

       //$(".dataTables_filter input").attr({ "data-toggle": "tooltip", "data-placement": "bottom", "title": "请用空格分隔多个关键词" });
        //    var toolbarHtml = ['<div class="input-group" style="">',
        //'			  <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"  style="color:#1589ed;"></span></span>',
        //'			  <input id="startTime" type="text" class="form-control" placeholder="Username" aria-describedby="basic-addon1">',
        //'			  <span class="input-group-addon" style="background: white;font-weight:bold;">到</span>',
        //'			  <input id="endTime" type="text" class="form-control" placeholder="Username" aria-describedby="basic-addon1">',
        //'			  <span class="btn btn-primary input-group-addon" style="font-weight:bold">查询</span>',
        //'			</div>'].join("");
        //    $("div.toolbar").html(toolbarHtml);

       

   
    }//initDataTables
    function initLineHighC(data) {
        var xAxisArr = [];
        var seriesArr = [];
        for (var i = 0; i < data.Table.length; i++) {
            xAxisArr.push(data.Table[i]["日期"]);
        }
        console.log(xAxisArr);
        var seriesarr1 = arrobjTocolumns(data.Table);
        seriesarr = arrdataToNumber(seriesarr1);
        console.log(seriesarr);
        $('#container').highcharts({
            chart: {
                type: 'line'
            },
            title: {
                text: '曲线分析'
            },
            subtitle: {
                text: null//'Source: WorldClimate.com'
            },
            xAxis: {
                categories: xAxisArr
            },
            yAxis: {
                title: {
                    text: null//'Temperature (°C)'
                }
            },
            colors: ['#ff3333', '#33ff66', '#8bbc21', '#910000', '#1aadce',
       '#492970', '#f28f43', '#77a1e5', '#c42525', '#a6c96a'],
            credits: {
                enabled: false
            },
            plotOptions: {
                line: {
                    dataLabels: {
                        enabled: false
                    },
                    enableMouseTracking: true
                }
            },
            series: seriesarr
        });
    }//initLineHighC
   
    function arrdataToNumber(arr) {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i]["data"] && typeof arr[i]["data"] == "object") {
                for (var j = 0; j < arr[i]["data"].length; j++) {
                    arr[i]["data"][j] = parseFloat(arr[i]["data"][j]);
                }
            }
        }
        return arr;
    }
   
    function dataToNumber(arr) {
        for (var i = 0; i < arr.length; i++) {
            for (var j in arr[i]) {
                if (typeof arr[i][j] == "string") {
                    arr[i][j] = parseFloat(arr[i][j]);
                }
            }
        }
        return arr;
    }
    function deleteField(arr1, arr2) {//arr1是数组对象，arr2存放要删除的对象属性；
        for (var i = 0; i < arr1.length; i++) {
            for (var j in arr1[i]) {
                if (typeof (arr1[i][j]) == "string") {
                    for (var z = 0; z < arr2.length; z++) {
                        if (j == arr2[z]) {
                            delete arr1[i][j];
                        }
                    }
                }
            }
        }
        return arr1;
    }
    function arrobjTocolumns(arr) { //数组中是obj的对象处理成一列一列的；
        arr = deleteField(arr,["日期","ID"]);
        //Object.prototype.Clone = function() {
        //    var objClone;
        //    if(this.constructor == Object) objClone = new this.constructor();
        //    else objClone = new this.constructor(this.valueOf());
        //    for(var key in this) {
        //        if(objClone[key] != this[key]) {
        //            if(typeof(this[key]) == 'object') {
        //                objClone[key] = this[key].Clone();
        //            } else {
        //                objClone[key] = this[key];
        //            }
        //        }
        //    }
        //    objClone.toString = this.toString;
        //    objClone.valueOf = this.valueOf;
        //    return objClone;
        //}
        var deepCopy= function(source) { 
            var result={};
            for (var key in source) {
                result[key] = typeof source[key]==='object'? deepCoyp(source[key]): source[key];
            } 
            return result; 
        }
        var seriesArr = [];
        var seriesObj = {};
        var arr2 = [];
         for(var i = 0; i < arr.length; i++) {//把arr.length写成几，就是series_data取几条数据
       // for (var i = 0; i < 10; i++) {
            var z = 0;
            for(var j in arr[i]) {
                if(typeof arr[i][j] == "function") {
                    continue;
                }
                if(arr2[z] == undefined) {
                    arr2[z] = arr[i][j];
                } else {
                    arr2[z] = arr2[z] + "," + arr[i][j];
                }
                z++;
            }
        }
        var m = 0;
        for(var k in arr[0]) {
            if(typeof arr[0][k] == "function") {
                continue;
            }
            if(k=="ID"){//在这里增加减少的查询字段；就是series少几个对象；
                continue;
            }
            seriesObj["name"] = k;
            seriesObj["data"] = arr2[m];
            seriesArr[m] = deepCopy(seriesObj);// seriesObj.Clone();
            m++;
        }
        for(var m=0;m<seriesArr.length;m++){//#region
            for(var n in seriesArr[m]){
                if(n=="data"){
                    seriesArr[m][n]=seriesArr[m][n].split(",");
                }
            }
        }
        return seriesArr;
    }//arrobjTocolumns
   

});//ready