using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollapseTile : MonoBehaviour
{
    public float collapseDelay = 1f;     // Thời gian chờ trước khi sụp tile
    public float respawnDelay = 3f;      // Thời gian chờ để tái tạo tile sau khi sụp
    private Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm là người chơi
        if (collision.gameObject.CompareTag("Player"))
        {
            // Xác định vị trí tile bị va chạm
            Vector3 hitPosition = Vector3.zero;

            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x;
                hitPosition.y = hit.point.y;

                // Lấy vị trí tile trong tilemap
                Vector3Int tilePos = tilemap.WorldToCell(hitPosition);

                // Bắt đầu Coroutine sụp và tái tạo tile tại vị trí đó
                StartCoroutine(CollapseAndRespawn(tilePos));
            }
        }
    }

    private IEnumerator CollapseAndRespawn(Vector3Int tilePos)
    {
        // Đợi trước khi làm sụp tile
        yield return new WaitForSeconds(collapseDelay);

        // Xóa tile tại vị trí tilePos
        TileBase tile = tilemap.GetTile(tilePos);
        if (tile != null)
        {
            tilemap.SetTile(tilePos, null);
        }

        // Đợi trước khi tái tạo lại tile
        yield return new WaitForSeconds(respawnDelay);

        // Khôi phục tile tại vị trí tilePos
        tilemap.SetTile(tilePos, tile);
    }
}
