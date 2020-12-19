var textArea = document.getElementById("pseudocode_text_area");
var output = document.getElementById("mermaid_preview");

mermaid.initialize({ startOnLoad: false });

textArea.addEventListener("change", (event) => {
    mermaid.render('theGraph', textArea.value, function (svgCode) {
        output.innerHTML = svgCode;
    });
});