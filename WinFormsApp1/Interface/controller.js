

window.chrome.webview.addEventListener('message', event => {
    app.LoadCells(event.data);

});