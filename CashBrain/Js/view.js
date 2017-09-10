var arr = [];
var answerArr = [];
var Useranswercr = [];
var Uservalue = [];
var totval = 0;
i = 0;
var icnt = 0;
var timertickcount = [20,20,20,20,20,20,20,20,20,20];
var correctanswercount=0;

function loadData() {
    $.ajax({
        url: "/Admin/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            
            var html = '';
            $.each(result, function (key, item) {
              
                html += '<tr>';
                html += '<td>' + item.Question + '</td>';
                html += '<td>' + item.Choice1 + '</td>';
                html += '<td>' + item.Choice2 + '</td>';
                html += '<td>' + item.Choice3 + '</td>';
                html += '<td>' + item.Choice4 + '</td>';
                html += '<td>' + item.CorrectAnswers + '</td>';
               // html += '<td><a href="#" onclick="return getbyID(' + item.ID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.ID + ')">Delete</a></td>';
                html += '</tr>';
                //arr.push(html);
                html;
            });
            
           
            $('.tbody').html(html);


           
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function loadDatacustomer() {
    $.ajax({
        url: "/Quiz/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            var qcoun;
            $.each(result, function (key, item) {
                qcoun = totval + 1;
                html = ''
                html+='<div class="col-lg-12">';
                html+='<br />';
                html+='<div class="col-lg-12">';
                html+='<div class="col-lg-8 questiondiv">';
                html += 'Q' + qcoun + '.' + item.Question;
                html+='</div>';
                html+='</div>';
                html+='</div>';
                html+='<br /><br /><br /><br /><br />';
                html+='<div class="col-lg-6">';
                html+='<table>';
                html+='<tr>';
                html += '<td><button class="button" value="' + item.Choice1 + '" onclick="changeanswerfrequently(this.value)">' + item.Choice1 + '</button></td>';
                html += '<td><button class="button" value="' + item.Choice2 + '" onclick="changeanswerfrequently(this.value)">' + item.Choice2 + '</button></td>';
                html+='</tr>';
                html+='<tr>';
                html += '<td><button class="button" value="' + item.Choice3 + '"  onclick="changeanswerfrequently(this.value)">' + item.Choice3 + '</button></td>';
                html += '<td><button class="button" value="' + item.Choice4 + '"  onclick="changeanswerfrequently(this.value)">' + item.Choice4 + '</button></td>';
                html+='</tr>';
                html+='</table>';
                html+='</div>';
                html+='<br/><br /><br /><br /><br />';
                arr[totval] = html;
                answerArr[totval] = item.CorrectAnswers;
                totval++;
            });
           // alert(answerArr);
            var value = arr[0];
            $('#maindata').html(value);
            document.getElementById('calquestioncount').innerHTML = icnt;
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

function changequestion()
{
    var htmls = document.getElementById('maindata').innerHTML;
    arr[icnt] = htmls;
    //alert(answerArr);
    var Tickvalue = document.getElementById('timer').innerHTML;

    Uservalue[icnt] = 1 + parseInt(Tickvalue,10);
    Useranswercr[icnt] = document.getElementById('UserAnswer').innerHTML;
    //alert(answerArr);
    //UserAnswer
    timertickcount[icnt] = count;
    icnt++;   
    var value = arr[icnt];
    $('#maindata').html(value);
    document.getElementById('calquestioncount').innerHTML = icnt;
    //document.getElementById('time11').innerHTML = count;
    cdreset();
    if(icnt==5)
    {
        document.getElementById('Finalanswercount').style.visibility='visible';
    }
}

function calulateAnswer() {
    
    
        if (Useranswercr.length !== answerArr.length) {
            //alert('answer count mismatch');
        }
        
        for (var i = 0, len = Useranswercr.length; i < len; i++) {
            if (Useranswercr[i] == answerArr[i]) {
               // alert(correctanswercount);
                //alert(Uservalue[i]);
                correctanswercount = parseInt(correctanswercount,10) + parseInt(Uservalue[i],10);
                //alert('corretc');
            }
            else
            {

                //alert('incorrect');
            }
        }
        alert('Correct Answer is' + correctanswercount);


    
}
    function PreviousQuestion() {
        var htmls = document.getElementById('maindata').innerHTML;
        arr[icnt] = htmls;
        timertickcount[icnt] = count;
        icnt--;
        var value = arr[icnt];
        $('#maindata').html(value);
        document.getElementById('calquestioncount').innerHTML = icnt;
        count = timertickcount[icnt];
        cdreset();
    }

    var t, count;

    function cddisplay() {
        document.getElementById('timer').innerHTML = count;
    }

    function countdown() {
        cddisplay();
        if (count === 0) {
            // changequestion();
        } else {
            count--;
            t = setTimeout(countdown, 1000);
        }
    }

    function cdpause() {
        clearTimeout(t);
    }

    function cdreset() {
        cdpause();
        cddisplay();
        count = timertickcount[icnt];

        countdown();
    }

    function changeanswerfrequently(valueselected) {
        //document.getElementById('displaycontent').innerHTML = valueselected;
        // alert('hello');
        //alert(valueselected);
        //var myDiv = document.getElementById("#btn4");
        //myDiv.setAttribute("style", "background-color:#3e8e41;");
        
         
         document.getElementById('UserAnswer').innerHTML = valueselected;
    }
