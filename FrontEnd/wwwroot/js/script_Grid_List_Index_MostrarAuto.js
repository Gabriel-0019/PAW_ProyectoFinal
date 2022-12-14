var li_links = document.querySelectorAll(".links ul li");
var view_wraps = document.querySelectorAll(".view_wrap");
var list_view = document.querySelector(".list-view");
var grid_view = document.querySelector(".grid-view");

li_links.forEach(function(link){
	link.addEventListener("click", function(){
		li_links.forEach(function(link){
			link.classList.remove("active");
		})

		link.classList.add("active");

		var li_view = link.getAttribute("data-view");

		view_wraps.forEach(function(view){
			view.style.display = "none";
		})

		if(li_view == "list-view"){
			list_view.style.display = "block";
		}
		else{
			grid_view.style.display = "block";
		}
	})
})

$('input').mouseleave(function () { // run anytime the value changes
	var firstValue = new Date($('#first').val());
	var secondValue = new Date($('#second').val());


	// To calculate the time difference of two dates
	var Difference_In_Time = secondValue.getTime() - firstValue.getTime();

	// To calculate the no. of days between two dates
	var Difference_In_Days = Difference_In_Time / (1000 * 3600 * 24);

	document.getElementById('total_expenses2').value = Difference_In_Days;
	// add them and output it
});
