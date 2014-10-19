      var uri = 'api/Article';

//      $(document).ready(function () {
//          // Send an AJAX request
//          $.getJSON(uri)
//          .done(function (data) {
//              $.each(data, function (key, item) {
//                  $('#articles tr:last')
//                  .after(formatRow(item))

//              });
//              $(".trArticle").hover(function () {
//                  // Hover over code
//                  //find value;
//                  var IdArticle = $(this).find('input[type=hidden]').val();
//                  console.log(IdArticle);
//                  getArticle(IdArticle);
//              }, function () {
//                  // Hover out code
//                  $('.tooltip').remove();
//              }).mousemove(function (e) {

//                  var mousex = e.pageX + 20; //Get X coordinates
//                  var mousey = e.pageY + 10; //Get Y coordinates
//                  $('.tooltip').css({ top: mousey, left: mousex })
//              });

//          });
      //      });

      $(document).ready(function () {
          $(".trArticle").hover(function () {
              // Hover over code
              //find value;
              //var IdArticle = 1;

              var IdArticle = $(this).find('td[data-name=Id]').html();

              getArticle(IdArticle);

          }, function () {
              // Hover out code
              $('.tooltip').remove();
          }).mousemove(function (e) {

              var mousex = e.pageX + 20; //Get X coordinates
              var mousey = e.pageY + 10; //Get Y coordinates
              $('.tooltip').css({ top: mousey, left: mousex })
          });


          $(this).find('.buyIt').click(function () {
              //console.log('buy');
              var IdArticle = $(this).siblings('td[data-name=Id]').html();
              //console.log($(this).siblings('td[data-name=Id]').html());
              $('#shoppingcart_cont').load('/Shop/Add/' + IdArticle);
          });
      });
      


      function formatRow(item) {
          return '<tr class="trArticle">' + '<td>' + item.Name + '<input type="hidden" value="' + item.Id.toString()  + '" id=key_"' + item.Id.toString() + '"' + '/>' + '</td>' + '<td>' + item.Summary + '</td>' + '<td>' + item.FormattedTotalPrice + '</td>' + '</tr>';
      }
      function handleArticle(data) {
          //console.log(data);
          var table = '<table>';
          table += '<tr>' + '<td>' + data.Name + '</td>';
          table += '<td>' + data.Summary + '</td>';
          table += '<td>' + data.FormattedPrice + ' (VAT ' + data.FormattedVAT + ' %)' + '</td></tr>';
          table += '<tr>' + '<td colspan="2">' + data.Description + '</td>';
          table += '<td> Total Price ' + data.FormattedTotalPrice + '</td>';
          table += '</tr></table>';
          
          $('<div class="tooltip"></div>')
          .append(table)
          .appendTo('body')
          .fadeIn('slow');

          return table;
      }
      function getArticle(idArticle) {

          $.getJSON(uri + '/' + idArticle)
          .done(function (data) {
              handleArticle(data);
          });
         
      }

