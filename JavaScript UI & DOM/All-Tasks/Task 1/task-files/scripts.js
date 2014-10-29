function createImagesPreviewer(selector, items) {
    var contentUl = document.createElement('ul');

    function appendContent(items) {
        var contentUl = document.createElement('ul');
        for (var i = 0; i < items.length; i += 1) {
            var miniContentDiv = document.createElement('div');
            var miniContentDivTitle = document.createElement('h2');
            var miniContentDivImg = document.createElement('img');


            miniContentDivTitle.innerHTML = items[i].title;
            miniContentDivTitle.style.textAlign = 'center';
            miniContentDivImg.setAttribute('src', items[i].url);
            miniContentDivImg.style.width = '190px';
            miniContentDivImg.addEventListener('click', function() {
                leftContainer.innerHTML = '';
                var bigTitle = document.createElement('h2');
                bigTitle.innerHTML = event.target.previousSibling.innerHTML;
                bigTitle.style.textAlign = 'center';
                leftContainer.appendChild(bigTitle);
                var bigImage = document.createElement('img');

                var bigImageWidth = leftContainer.style.width;
                bigImage.style.width = bigImageWidth;
                bigImage.setAttribute('src', event.target.getAttribute('src'));
                leftContainer.appendChild(bigImage);
            })

            miniContentDiv.onmouseover = function() {
                event.target.style.background = 'grey';
                event.target.childNodes.background = 'grey';
            }
            miniContentDivImg.onmouseover = function() {
                event.target.parentNode.style.background = 'grey';
                event.target.previousSibling.style.background = 'grey';
            }
            miniContentDivTitle.onmouseover = function() {
                event.target.parentNode.style.background = 'grey';

                event.target.nextSibling.style.background = 'grey';
            }
            miniContentDiv.onmouseout = function() {
                event.target.style.background = 'white';
                event.target.childNodes.background = 'white';
            }
            miniContentDivImg.onmouseout = function() {
                event.target.parentNode.style.background = 'white';
                event.target.previousSibling.style.background = 'white';
            }
            miniContentDivTitle.onmouseout = function() {
                event.target.parentNode.style.background = 'white';
                event.target.nextSibling.style.background = 'white';
            }



            miniContentDiv.appendChild(miniContentDivTitle);
            miniContentDiv.appendChild(miniContentDivImg);
            rightContainer.appendChild(miniContentDiv);
        };
    }


    function createFilter(items, contentUl) {
        console.log(items);
        var filterBarLabel = document.createElement('span');
        filterBarLabel.innerHTML += 'Filter:';
        rightContainer.appendChild(filterBarLabel);

        var filterBar = document.createElement('input');
        filterBar.addEventListener('change', function() {
            for (var i = 0; i < items.length; i++) {

                contentUl.style.display = 'none';


                var indexOfSubStr = items[i].title.indexOf(filterBar.value);
                console.log(indexOfSubStr);
                //console.log(filterBar.value)
                if (items[i].title.toLowerCase().indexOf(filterBar.value) > -1) {
                    alert('Match found!')
                    //items[i].style.display = 'list-item'
                };
            };
        })

        rightContainer.appendChild(filterBar);

    }

    function createContainers(contentUl) {

        var prevContainer = document.createElement('div');
        prevContainer.setAttribute('id', 'container');
        prevContainer.style.width = '600px';
        prevContainer.style.height = '400px';
        prevContainer.style.border = '2px solid black';
        document.body.appendChild(prevContainer);


        var leftContainer = document.createElement('div');
        leftContainer.setAttribute('id', 'leftContainer');
        leftContainer.style.width = '396px';
        leftContainer.style.height = '400px';
        //leftContainer.style.border = '2px solid blue';
        leftContainer.style.display = 'inline-block';
        leftContainer.style.position = 'absolute';
        prevContainer.appendChild(leftContainer);

        var rightContainer = document.createElement('div');
        rightContainer.setAttribute('id', 'rightContainer');
        rightContainer.style.width = '196px';
        rightContainer.style.height = '400px';
        //rightContainer.style.border = '2px solid red';
        rightContainer.style.marginLeft = '400px';
        rightContainer.style.display = 'inline-block';
        prevContainer.appendChild(rightContainer);

        createFilter(items, contentUl);
        appendContent(items, contentUl);

        rightContainer.style.overflowY = 'scroll';
        rightContainer.style.overflowX = 'hidden';
    }
    createContainers(contentUl);

}