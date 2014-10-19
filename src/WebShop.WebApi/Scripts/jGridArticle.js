// the url to make the Ajax calls
var jqDataUrl = "shop/ListArticles";
$(document).ready(function () {

    // Set up the jquery grid
    $("#articles").jqGrid({
        // Ajax related configurations
        url: jqDataUrl,
        datatype: "json",
        mtype: "POST",

        // Specify the column names
        colNames: ["Id", "Name", "Summary", "FormattedTotalPrice"],

        // Configure the columns
        colModel: [
            { name: "Id", index: "Id", width: 40, align: "left" },
            { name: "Name", index: "Name", width: 100, align: "left" },
            { name: "Summary", index: "Score", width: 200, align: "left" },
            { name: "Price", index: "TotalPrice", width: 200, align: "left"}],

        // Grid total width and height
        width: 550,
        height: 200,

        // Paging
        toppager: true,
        pager: $("#jqTablePager"),
        rowNum: 5,
        rowList: [5, 10, 20],
        viewrecords: true, // Specify if "total number of records" is displayed

        // Default sorting
        sortname: "Id",
        sortorder: "asc",

        // Grid caption
        caption: "List of Articles"
    }).navGrid("#jqTablePager",
            { refresh: true, add: false, edit: false, del: false },
                {}, // settings for edit
                {}, // settings for add
                {}, // settings for delete
                {sopt: ["cn"]} // Search options. Some options can be set on column level
         );
});