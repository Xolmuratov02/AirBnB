namespace AirBnB.Domain.Common.Collections;

public class AsyncEnumerable<TElement>(IEnumerable<TElement> source) : IAsyncEnumerable<TElement>
{
    public async IAsyncEnumerator<TElement> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        foreach (var item in source)
            yield return await Task.FromResult(item);
    }
}