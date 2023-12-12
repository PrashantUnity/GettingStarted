window.generateImage = function (id) {
    html2canvas(document.getElementById(id)).then(function (canvas) {
        var image = canvas.toDataURL('image/png');

        var a = document.createElement('a');
        a.href = image;
        a.download = 'generated_image.png';
        a.click();
    });
}
