function showJsGrid() {
    
    var clients = [
        { "Name": "Harry", "Age": 28, "Country": "Canada", "Married": false },
        { "Name": "Johny", "Age": 35, "Country": "France", "Married": true },
        { "Name": "Leena", "Age": 39, "Country": "USA", "Married": false },
        { "Name": "Rohit", "Age": 26, "Country": "India", "Married": true },
        { "Name": "Diana", "Age": 32, "Country": "Scotland", "Married": false }
    ];

    $("#dataGrid").jsGrid({
        width: "500px",
        height: "210px",
        sorting: true,
        paging: true,
        pageSize: 3,
        pageButtonCount: 3,

        data: clients,

        fields: [
            { name: "Name", type: "text", width: 100},
            { name: "Age", type: "number", width: 50 },
            { name: "Country", type: "text", width: 100 },
            { name: "Married", type: "checkbox", title: "Is Married", sorting: false }
        ]
    });
}