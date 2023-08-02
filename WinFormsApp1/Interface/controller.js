

window.chrome.webview.addEventListener('message', event => {
    let args = event.data;
    if (args.Method == "LoadCells") {
        app.LoadCells(args.Data)

    }

    else if (args.Method == "UpdateCells") {
        app.UpdateCells(args.Data)
    }
});