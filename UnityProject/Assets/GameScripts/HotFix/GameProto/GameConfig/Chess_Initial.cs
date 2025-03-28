
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace GameConfig
{
public partial class Chess_Initial
{
    private readonly System.Collections.Generic.Dictionary<int, Chess_InitialItem> _dataMap;
    private readonly System.Collections.Generic.List<Chess_InitialItem> _dataList;
    
    public Chess_Initial(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, Chess_InitialItem>();
        _dataList = new System.Collections.Generic.List<Chess_InitialItem>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Chess_InitialItem _v;
            _v = Chess_InitialItem.DeserializeChess_InitialItem(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, Chess_InitialItem> DataMap => _dataMap;
    public System.Collections.Generic.List<Chess_InitialItem> DataList => _dataList;

    public Chess_InitialItem GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Chess_InitialItem Get(int key) => _dataMap[key];
    public Chess_InitialItem this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

