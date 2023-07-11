var api = window.chrome.webview.hostObjects.apiwebcontroller;

var app = new Vue({
    el: "#app",
    data: {
        coordinates: {
            left: "100px",
            top: "100px"
        },
        form: null

    },
    mounted() {
        this.form = new bootstrap.Modal(this.$refs.CellInfo);
    },
    methods: {
        ShowCellInfo() {
            api.GetPosition();

              this.form.show();
        },
        HideCellInfo() {
            this.form.hide();

        },
        SetPosition(point) {
            this.coordinates = point;
        }

    }
})



