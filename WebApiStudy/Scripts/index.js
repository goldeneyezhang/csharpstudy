$(function () {

	$.ajax({
		type: "get",
		url: "http://localhost:55603/api/Charging/",
		data: {},
		beforeSend: function (XHR) {
			//发送ajax请求之前向http的head里面加入验证信息
			XHR.setRequestHeader('Authorization', 'BasicAuth ' + Ticket);
		},
		success: function (data, status) {
			if (status == "success") {
				$("#div_test").html(data);
			}
		},
		error: function (e) {
			$("#div_test").html("Error");
		},
		complete: function () {
		}
	});
});