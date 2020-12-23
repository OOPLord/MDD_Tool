var textArea = document.getElementById("pseudocode_text_area");
var preview = document.getElementById("mermaid_preview");


mermaid.initialize({ startOnLoad: false });


$(document).ready(function () {
    mermaid.render('theGraph', textArea.value, function (svgCode) {
        preview.innerHTML = svgCode;
    });
})

$(textArea).change((event) => {
    mermaid.render('theGraph', textArea.value, function (svgCode) {
        preview.innerHTML = svgCode;
    });
})

function update() {
    $.ajax({
        type: 'GET',
        url: 'Home?handler=FindUser',
        success: function (data) {
            alert(data);
        },
        error: function (error) {
            alert("Error: " + error);
        }
    })
}