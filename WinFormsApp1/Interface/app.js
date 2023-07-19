var api = window.chrome.webview.hostObjects.apiwebcontroller;

var app = new Vue({
    el: "#app",
    data: {

        cells: [],
        form: null

    },
    mounted() {
        this.form = new bootstrap.Modal(this.$refs.CellInfo);
        api.LoadCells();
    },
    methods: {
        ShowCellInfo() {

              this.form.show();
        },
        HideCellInfo() {
            this.form.hide();

        },
        LoadCells(cells) {
            this.cells = cells;
        }
        
      

    }
})



