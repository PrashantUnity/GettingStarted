export function cartAnimation(box1, box2) {
    $(box2).click(function () {
        $(this).removeClass(box2);
        $(this).addClass(box1);
    });
}