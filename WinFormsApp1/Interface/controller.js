

window.chrome.webview.addEventListener('message', event => {

    app.SetPosition(event.data)

});