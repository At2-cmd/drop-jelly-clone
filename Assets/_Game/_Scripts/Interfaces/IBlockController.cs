public interface IBlockController
{
    void GenerateNewBlock();
    void CheckIfMatchOccurs();
    void AddSelfIntoBlocksList(BlockEntity block);
    void RemoveSelfFromBlocksList(BlockEntity block);
    BlockEntity GetNextUnplacedBlock { get; }
}
