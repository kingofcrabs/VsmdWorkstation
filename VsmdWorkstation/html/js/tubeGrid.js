window.TubeGrid = (function () {
    var defaultSettings = {
		blockCount: 1,
        tubeWidth: 20,
        tubeHeight: 20
    }
    const CHAR_CODE_A = 65;
    function TubeGrid(container, options_) {
        this.container = container;
        this.options = options_ || {};

        this.tubeWidth = options_.tubeWidth || defaultSettings.tubeWidth;
        this.tubeHeight = options_.tubeHeight || defaultSettings.tubeHeight;
        this.blockCount = options_.blockCount || defaultSettings.blockCount;
        this.rowCount = options_.rowCount;
        this.columnCount = options_.columnCount;
        this.tubeEleArr = [];


        this.renderHeaders = function($table) {
			var $headerRow = $("<div class='grid-headers'></div>");
			for(let i = 0; i < this.columnCount; i++){
				let $headerCell = $("<div class='grid-header'>" + String.fromCharCode(CHAR_CODE_A + i) + "</div>");
				$headerRow.append($headerCell);
			}
			$(this.container).append($headerRow);
		}
        this.render = function() {
            if (!this.rowCount || !this.columnCount) {
                return;
            }
            let $con = $(this.container);
            //let conWidth = this.tubeWidth * this.columnCount + parseInt($con.css('padding-left')) + parseInt($con.css('padding-right'));
            //$con.width(conWidth);
            $con.addClass("tubeGrid");

            let $table = $('<table class="table"></table>');
			this.renderHeaders($table);



            // for (let i = 0; i < this.rowCount; i++) {
            //     let $rowEle = $("<div class='grid-row'></div>");
            //     for (let j = 0; j < this.columnCount; j++) {
            //         let posClass = "r" + (i+1) + " c" + (j+1);
            //         let $cell = $("<div class = 'grid-cell tube " + posClass + "' title=" + (i+1) + "," + (j+1) + "></div>");
            //         $cell.data("options", {row: i+1, column: j+1});
            //         $rowEle.append($cell);
            //     }
            //     $con.append($rowEle);
            // }
            // this.enableBoxSelection();
        }

        this.enableBoxSelection = function() {
            function clearBubble(e) {
                if (e.stopPropagation) {
                    e.stopPropagation();
                } else {
                    e.cancelBubble = true;
                }

                if (e.preventDefault) {
                    e.preventDefault();
                } else {
                    e.returnValue = false;
                }
            }
            var $container = $(this.container);
            $container
                .on('mousedown', function(eventDown) {
                    //  设置选择的标识
                    var isSelect = true;
                    //  创建选框节点
                    var $selectBoxDashed = $('<div class="select-box-dashed"></div>');
                    $('body').append($selectBoxDashed);
                    //  设置选框的初始位置
                    var startX = eventDown.x || eventDown.clientX;
                    var startY = eventDown.y || eventDown.clientY;
                    $selectBoxDashed.css({
                        left: startX,
                        top : startY
                    });
                    //  根据鼠标移动，设置选框宽高
                    var _x = null;
                    var _y = null;
                    //  清除事件冒泡、捕获
                    clearBubble(eventDown);
                    //  监听鼠标移动事件
                    $container.on('mousemove', function(eventMove) {
                        //  设置选框可见
                        $selectBoxDashed.css('display', 'block');
                        //  根据鼠标移动，设置选框的位置、宽高
                        _x = eventMove.x || eventMove.clientX;
                        _y = eventMove.y || eventMove.clientY;
                        //  暂存选框的位置及宽高，用于将 select-item 选中
                        var _left   = Math.min(_x, startX);
                        var _top    = Math.min(_y, startY);
                        var _width  = Math.abs(_x - startX);
                        var _height = Math.abs(_y - startY);
                        $selectBoxDashed.css({
                            left  : _left,
                            top   : _top,
                            width : _width,
                            height: _height
                        });
                        let boxPos = $selectBoxDashed[0].getBoundingClientRect();
                        //  遍历容器中的选项，进行选中操作
                        $container.find('.grid-cell').each(function(idx, val) {
                            var $item = $(val);
                            var elePos = val.getBoundingClientRect();
                            let cx = elePos.left + elePos.width / 2;
                            let cy = elePos.top + elePos.height / 2;
                            //console.log($(val));
                            //console.log(`cx: ${cx}, boxPos.left: ${boxPos.left}, boxPos.right: ${boxPos.right}`);
                            //console.log(`cy: ${cy}, boxPos.top: ${boxPos.top}, boxPos.bottom: ${boxPos.bottom}`);
                            if((cx > boxPos.left && cx < boxPos.right) &&
                                (cy > boxPos.top && cy < boxPos.bottom)){
                                if(!$item.hasClass("selected")){
                                    $item.addClass('selected');
                                }
                            } else {
                                if($item.hasClass("selected")){
                                    $item.removeClass('selected');
                                }

                            }
                        });
                        //  清除事件冒泡、捕获
                        clearBubble(eventMove);
                    });

                    $(document).on('mouseup', function() {
                        $container.off('mousemove');
                        $selectBoxDashed.remove();

                        // if (selectCallback) {
                        //     selectCallback();
                        // }
                    });
                })
                .on('click', '.grid-cell', function(ev) {
                    if(ev.ctrlKey) {
                        $(this).toggleClass('selected');
                    } else {
                        $container.find('.grid-cell.selected').removeClass('selected');
                        $(this).addClass('selected');
                    }

                });
        }

        this.render();
    }

    return TubeGrid;
})();