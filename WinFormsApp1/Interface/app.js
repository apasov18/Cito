var api = window.chrome.webview.hostObjects.apiwebcontroller;






var recognition = new (window.SpeechRecognition ||
    window.webkitSpeechRecognition ||
    window.mozSpeechRecognition ||
    window.msSpeechRecognition)();

function Speech() {
   

    recognition.lang = "ru-Ru";
    recognition.maxAlternatives = 1;
    recognition.interimResults = false
    recognition.start();
    recognition.onresult = function (event) {
        var speechResult = event.results[event.results.length - 1][0].transcript;
        console.log(speechResult);
        api.CallBackSpeech(speechResult);

    }

    recognition.onspeechend = function () {
        setTimeout(() => recognition.start(), 1000);
    }
}


var app = new Vue({
    el: "#app",
    data: {

        cells: [],
        form: null,
        current: null

    },
    mounted() {
        this.form = new bootstrap.Modal(this.$refs.CellInfo);
        api.LoadCells();

    },
    methods: {
        ShowCellInfo(cell) {
            this.current = cell;
            this.form.show();
            Speech();

        },
        HideCellInfo() {
            this.form.hide();

        },
        LoadCells(cells) {
            this.cells = cells;
            setInterval(() => {
                let json = JSON.stringify(this.cells)
                api.UpdateCells(json);
            }, 500)
        },
        UpdateCells(newCells) {
            this.cells = newCells;

        }



    }
})


window.chrome.webview.addEventListener('message', event => {
    let args = event.data;
    if (args.Method == "LoadCells") {
        app.LoadCells(args.Data)

    }

    else if (args.Method == "UpdateCells") {
        app.UpdateCells(args.Data)
    }
});




