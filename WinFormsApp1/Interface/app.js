var api = window.chrome.webview.hostObjects.apiwebcontroller;

var app = new Vue({
    el: "#app",
    data: {

        cells: [
            {
                life: 100,
                style: {
                    width: "150px",
                    height: "150px",
                    left: "100px",
                    top: "100px"

                },
                mitochondrions: [
                    {

                        style: {
                            left: "100px",
                            top: "100px",
                            transform: "rotate(45deg)"
                        },
                    },
                    {
                        style: {
                            left: "10px",
                            top: "30px",
                            transform: "rotate(110deg)"


                        },
                    },
                    {

                        style: {
                            left: "30px",
                            top: "70px",
                            transform: "rotate(-10deg)"


                        },
                    
                    },
                ]
            },

            {
                life: 100,
                style: {
                    width: "100px",
                    height: "100px",
                    left: "500px",
                    top: "300px"

                },

                mitochondrions: [
                    {

                        style: {
                            left: "100px",
                            top: "100px",
                            transform: "rotate(45deg)"


                        },
                    },
                    {

                        style: {
                            left: "10px",
                            top: "30px",
                            transform: "rotate(110deg)"


                        },
                    },
                    {

                    
                        style: {
                            left: "30px",
                            top: "70px",
                            transform: "rotate(-10deg)"


                        },
                    },
                ]
            },
        ],
        form: null

    },
    mounted() {
        this.form = new bootstrap.Modal(this.$refs.CellInfo);
    },
    methods: {
        ShowCellInfo() {
            api.GetPosition();

            /*  this.form.show();*/
        },
        HideCellInfo() {
            this.form.hide();

        },
        SetPosition(point) {
            this.style = point;
        }

    }
})



