var api = window.chrome.webview.hostObjects.apiwebcontroller;

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



