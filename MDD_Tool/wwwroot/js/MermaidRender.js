var textArea = document.getElementById("pseudocode_text_area");
var preview = document.getElementById("mermaid_preview");


mermaid.initialize({ startOnLoad: false });


preview.addEventListener("load", (event) => {
    mermaid.render('theGraph', textArea.value, function (svgCode) {
        preview.innerHTML = svgCode;
    });
});

textArea.addEventListener("change", (event) => {
    mermaid.render('theGraph', textArea.value, function (svgCode) {
        preview.innerHTML = svgCode;
    });
});