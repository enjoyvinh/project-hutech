// --------------------------------------------------
/*
 * JavaScript標準のオブジェクトの拡張
 *
 * @author JBCC Satoshi Hiraga
 */
//--------------------------------------------------

/*
 * プロトタイプに任意の関数を追加できるような仕掛け
 */
Function.prototype.method = function(name, func) {
	if (!this.prototype[name]) {
		this.prototype[name] = func;
		return func;
	}
};

/*
 * Stringオブジェクトに左トリム関数を追加
 */
String.method('ltrim', function() {
	return this.replace(/^\s+/g, '');
});

/*
 * Stringオブジェクトに右トリム関数を追加
 */
String.method('rtrim', function() {
	return this.replace(/\s+$/g, '');
});

/*
 * Stringオブジェクトに左右トリム関数を追加
 */
String.method('trim', function() {
	return this.ltrim().rtrim();
});

String.method('pad', function(padString, length) {
    var str = this;
    while (str.length < length)
        str = padString + str;
    return str;
});
